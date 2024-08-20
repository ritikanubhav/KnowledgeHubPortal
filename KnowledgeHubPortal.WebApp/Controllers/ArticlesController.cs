using System.Reflection.Metadata.Ecma335;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnowledgeHubPortal.WebApp.Controllers
{
	public class ArticlesController : Controller
	{
		private IArticlesRepository aRepo;
		private ICategoryRepository cRepo;

		public ArticlesController(IArticlesRepository aRepo,ICategoryRepository cRepo) 
		{
			this.aRepo = aRepo;
			this.cRepo=cRepo;
		}

		// Browse Articles
		public IActionResult Index(int cid=0)
		{
			//frtch all approve articles for browse
			var articlesToBrowse=aRepo.GetArticlesForBrowse(cid);
			//fetch all categories
			//var categories = cRepo.GetAll();
			var categories = from cat in cRepo.GetAll()
							 select new SelectListItem
							 {
								 Text=cat.CategoryName,
								 Value=cat.CategoryId.ToString()
							 };
			ViewBag.Categories = categories;    //ViewBag takes a key name and store value
												//ViewData["Categories"]=categories;
			return View(articlesToBrowse); //sending articlesData as model
		}
		[HttpGet]
		[Authorize]
		public IActionResult Submit()
		{
			var categories = from cat in cRepo.GetAll()
							 select new SelectListItem
							 {
								 Text = cat.CategoryName,
								 Value = cat.CategoryId.ToString()
							 };
			ViewBag.Categories = categories;
			return View();
		}
		[HttpPost]
		[Authorize]
		public IActionResult Submit(Article article)
		{
			//validate 
			if (!ModelState.IsValid)
			{
				return View();
			}
			//save
			article.DateSubmitted = DateTime.Now;
			article.IsApproved=false;
			if (User.Identity.IsAuthenticated)
				article.SubmittedBy = User.Identity.Name; //using buit in user class
			else
				article.SubmittedBy = "Unknown";

			aRepo.Submit(article);
			TempData["Message"]=$"Article {article.Title} submitted successfully for review";
			return RedirectToAction("Index");
		}
		[HttpGet]
		[Authorize(Roles ="admin")]
		public IActionResult Approve(int cid=0)
		{
			var articlesToReview = aRepo.GetArticlesForReview(cid);
            var categories = from cat in cRepo.GetAll()
                             select new SelectListItem
                             {
                                 Text = cat.CategoryName,
                                 Value = cat.CategoryId.ToString()
                             };
            ViewBag.Categories = categories;
            return View(articlesToReview);
		}
		[HttpPost]
        [Authorize(Roles = "admin")]

        public IActionResult Approve(List<int> ids)
		{
			aRepo.Approve(ids);
			TempData["Message"] = $"{ids.Count} Aricles Approved";
			return RedirectToAction("Approve");
        }
        [Authorize(Roles = "admin")]
        public IActionResult Reject(List<int> ids)
        {
            aRepo.Reject(ids);
            TempData["Message"] = $"{ids.Count} Aricles Rejected";
            return RedirectToAction("Approve");
        }
    }
}

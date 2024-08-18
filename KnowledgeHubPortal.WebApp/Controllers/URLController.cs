using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KnowledgeHubPortal.WebApp.Controllers
{
	//Url: .../categories/index
	public class URLController : Controller
	{
		//injecting repo object in class through constructor ---DIP
		IArticleRepo articleRepo = null;

		public URLController(IArticleRepo repo)
		{
			articleRepo = repo;
		}
		public IActionResult Index()
		{
			//get the list of articles
			List<Article> articles = articleRepo.GetAll();

			//get the list of categories
			var catRepo = HttpContext.RequestServices.GetService<ICategoryRepository>();
			List<Category> categories=catRepo.GetAll();

			// wrap the both list in acontainer object
			// Pass the lists to the view using ViewBag
			ViewBag.Categories =categories;
			ViewBag.Articles=articles;

			//return view
			return View();
		}
		public IActionResult Browse(int categoryId)
		{
            List<Article> articles = articleRepo.GetArticlesByCategory(categoryId);
			ViewBag.Articles = articles;

			var catRepo = HttpContext.RequestServices.GetService<ICategoryRepository>();
			List<Category> categories = catRepo.GetAll();

			ViewBag.Categories = categories;
			ViewBag.selectedCategoryid=categoryId;
			return View("Index");
        }
		public IActionResult Submit()
		{
            //get the list of categories
            var catRepo = HttpContext.RequestServices.GetService<ICategoryRepository>();
            List<Category> categories = catRepo.GetAll();
            ViewBag.Categories = categories;
            return View();
		}
		public IActionResult Save(Article article)
		{
			//Validate the data before saving
			if (!ModelState.IsValid)
			{
                //foreach (var error in ModelState)
                //{
                //    var key = error.Key;
                //    var errorMessage = error.Value.Errors.FirstOrDefault()?.ErrorMessage;
                //    // Log the validation errors for debugging
                //    System.Diagnostics.Debug.WriteLine($"Validation error in {key}: {errorMessage}");
                //}
                return RedirectToAction("Submit");
			}
			articleRepo.Add(article);
			return RedirectToAction("Index");
		}
		public IActionResult ShowNotApprovedArticles(int categoryId = 0)
		{
			
				// Fetch not approved articles
				var articles = articleRepo.GetNotApprovedArticles();
				
				// Filter articles by category if id is provided
				if (categoryId == 0)
				{
					ViewBag.Articles = articles;
				}
				else
				{
					var articlesByCategory = articles.Where(article => article.CategoryId == categoryId).ToList();
					ViewBag.Articles = articlesByCategory;
				}

				// Retrieve categories from the repository
				var catRepo = HttpContext.RequestServices.GetService<ICategoryRepository>();
				List<Category> categories = catRepo.GetAll();

				// Set view data
				ViewBag.Categories = categories;
				ViewBag.SelectedCategoryId = categoryId;

				// Return the view
				return View("ShowNotApprovedArticles");
		}

		[HttpPost]
		public ActionResult ProcessArticles(IEnumerable<int> selectedArticles, string actionType)
		{
			if (actionType == "Approve")
			{
				System.Diagnostics.Debug.WriteLine($"Approve clicked");
				// Process approved articles
				ApproveArticles(selectedArticles);
			}
			else if (actionType == "Reject")
			{
				System.Diagnostics.Debug.WriteLine($"Reject clicked");

				// Process rejected articles
				RejectArticles(selectedArticles);
			}

			return RedirectToAction("ShowNotApprovedArticles"); // Redirect to appropriate action
		}

		private void ApproveArticles(IEnumerable<int> articleIds)
		{
			// Implement your logic to approve articles
			foreach (var id in articleIds)
			{
				articleRepo.ApproveArticleById(9);
				System.Diagnostics.Debug.WriteLine($"{id}");
			}
			
		}

		private void RejectArticles(IEnumerable<int> articleIds)
		{
			// Implement your logic to reject articles
			foreach(var id in articleIds)
			{
				articleRepo.DeleteArticleById(id);
				System.Diagnostics.Debug.WriteLine($"{id}");
			}
		}
	}
}


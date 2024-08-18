using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class CategoriesController : Controller
    {
		//Url: .../categories/index

		//injecting repo object in class through constructor ---DIP
		ICategoryRepository categoryRepository = null;

		public CategoriesController(ICategoryRepository repo)
        {
            categoryRepository = repo;
        }
        public IActionResult Index()
        {
            //step 1: fetch the category list from data layer
            //ICategoryRepository categoryRepository = new CategoryRepository(); //BAD - DIP

            //step 2: send the list of categories to view
            List<Category> categories = categoryRepository.GetAll();

            //step 3: send the list to view
            return View(categories);
        }
        public IActionResult Add()
        {
            return View(); 
        }

        public IActionResult Save(Category category)
        {
            //Validate the data before saving
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            //ICategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.Create(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //get Category object bY category Id
            //ICategoryRepository categoryRepository = new CategoryRepository();
            Category categoryToEdit = categoryRepository.GetById(id);
            //return View with CategoryDetails to be edited
            return View(categoryToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //Validate the data before saving
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            //ICategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.Update(category);
            return RedirectToAction("Index");
        }
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
           
            //ICategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.Delete(id);
			
			return RedirectToAction("Index");
		}
    }
}

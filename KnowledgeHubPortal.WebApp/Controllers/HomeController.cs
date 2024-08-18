using System.Diagnostics;
using KnowledgeHubPortal.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // domain/Home/Index --execute the method
        public IActionResult Index()
        {
            return View();
        }
        // domain/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        // domain/Home/Hello
        //public string Hello()
        //{
        //    return "welcome to hello page";
        //}
        public IActionResult Hello()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private UserManager<IdentityUser> userManager;
        // have similar RoleManager and others
        public UsersController(UserManager<IdentityUser> userManager)
        {
            this.userManager=userManager;
        }
        [Authorize(Roles="admin")]
        public IActionResult Index()
        {
           var users= userManager.Users.ToList();
            return View(users);
        }
    }
}

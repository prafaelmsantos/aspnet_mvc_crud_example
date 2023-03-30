using aspnet_mvc_crud_example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace aspnet_mvc_crud_example.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register(int? id)
        {
            if (id.HasValue && UserModel.UsersList.Any(u => u.Id == id))
            {
                var user = UserModel.UsersList.Single(u => u.Id == id);
                return View(user);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            UserModel.Save(user);
            return RedirectToAction("Users");
        }

        public IActionResult Users()
        {
            return View(UserModel.UsersList);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && UserModel.UsersList.Any(u => u.Id == id))
            {
                var user= UserModel.UsersList.Single(u => u.Id == id);
                return View(user);
            }
            return RedirectToAction("Users");
        }

        [HttpPost]
        public IActionResult Delete(UserModel user)
        {
            UserModel.Delete(user.Id);
            return RedirectToAction("Users");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

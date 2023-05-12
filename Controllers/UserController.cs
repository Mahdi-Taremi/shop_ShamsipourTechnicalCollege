using Microsoft.AspNetCore.Mvc;
using shop_MahdiTaremi.Models;

namespace shop_MahdiTaremi.Controllers
{
 
    public class UserController : Controller
    {
        private readonly dbShop dbUser;
        public UserController(dbShop dbUser)
        {
            this.dbUser = dbUser;
        }

        public IActionResult Index()
        {
            var query = dbUser.User.ToList();

            return View(query);
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUserAction(User f)
        {
            dbUser.User.Add(f);
            dbUser.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

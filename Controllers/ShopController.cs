using Microsoft.AspNetCore.Mvc;
using shop_MahdiTaremi.Models;

namespace shop_MahdiTaremi.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();


            Product objects = new Product();
            objects.Id = 1;
            objects.Name = "Name";
            objects.Price = 20;  
            objects.Quantity = 1;  
            objects.Color = "black";
            objects.Description = "Test 1";
            products.Add(objects);

             objects = new Product();
            objects.Id = 2;
            objects.Name = "Name2";
            objects.Price = 22;
            objects.Quantity = 2;
            objects.Color = "green";
            objects.Description = "Test 2";
            products.Add(objects);

            objects = new Product();
            objects.Id = 3;
            objects.Name = "Name3";
            objects.Price = 23;
            objects.Quantity = 3;
            objects.Color = "blue";
            objects.Description = "Test 3";
            products.Add(objects);

            var query = products.Where(x => x.Name == "Name2").ToList();

            return View();
        }

    }
}

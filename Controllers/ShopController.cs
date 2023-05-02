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

             var query = products.ToList();
            // var querySelect = products.ToList().Select(items => new {
            var querySelect = products.Select(items => new {
                items.Id,
                items.Name,
                items.Price,
                items.Quantity,
                items.Color,
                items.Description
            }).ToList(); 
           // var querySelect =query.Select(items => new {
           //    items.Id,
           //    items.Name,
           //    items.Price,
           //     items.Quantity,
           //    items.Color,
           //    items.Description 
           // });
            // var query = products.Where(x => x.Name == "Name2").ToList();
            // var query = products.Where(x => x.Id == 3).SingleOrDefault();
            // var query = products.Where(x => x.Id == 3).FirstOrDefault();
            // var query = products.Where(x => x.Id == 3).LastOrDefault();
            // var query = products.Where(x => x.Id == 3).ToList();
            // var query = products.Where(x => x.Name == "Name2").Any();
            // var query = products.Where(x => x.Name == "Name2").Count();
            // var query = products.Where(x => x.Name.Contains("Name2")).ToList();

            return View(query);
        }

    }
}

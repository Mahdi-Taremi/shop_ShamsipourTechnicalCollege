using Microsoft.AspNetCore.Mvc;
using shop_MahdiTaremi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop_MahdiTaremi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly dbShop dbShop;
        public ProductAPIController(dbShop dbShop)
        {
            this.dbShop = dbShop;
        }
        // GET: api/<ProductAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // return "Test True";

            var query = dbShop.Product.Where(x => x.Id == id).SingleOrDefault();
            if (query == null)
            {
                return "UnSuccessfull Add To Basket";
            } else
            {
                // return "Test";

                Basket basketdb = new Basket();
                //basketdb.Id = id; IdBasket
                //basketdb.BasketId = id;
                basketdb.BasketId = id;
                dbShop.Basket.Add(basketdb);
                dbShop.SaveChanges();
              var qCount = dbShop.Product.Count(); 
                return "Successfull Add To Basket" +" "+ qCount.ToString();
                //return "Successfull Add To Basket";
            }
        }

        // POST api/<ProductAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

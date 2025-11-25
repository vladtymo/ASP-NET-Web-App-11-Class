using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_11Class.Models;

namespace WebApp_11Class.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static List<Product> products = new()
        {
            new Product { Id = 1, Title = "Laptop", Category = "Electronics", Price = 1200, Quantity = 10 },
            new Product { Id = 2, Title = "Desk Chair", Category = "Furniture", Price = 150, Quantity = 25 },
            new Product { Id = 3, Title = "Notebook", Category = "Stationery", Price = 5, Quantity = 100 },
            new Product { Id = 4, Title = "Smartphone", Category = "Electronics", Price = 800, Quantity = 15 },
            new Product { Id = 5, Title = "Coffee Mug", Category = "Kitchenware", Price = 12, Quantity = 50 }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }   

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var item = products.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound(); // 404

            return View(item);
        }

        [HttpPost]
        public IActionResult SaveNewProduct(Product element)
        {
            products.Add(element);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product element)
        {
            var index = products.FindIndex(x => x.Id == element.Id);
            products[index] = element;

            return RedirectToAction("AdminPanel");
        }

        public IActionResult AdminPanel()
        {
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            // delete logic
            var item = products.Find(x => x.Id == id);

            if (item == null)
                return NotFound(); // 404

            products.Remove(item);

            return RedirectToAction("AdminPanel");
        }

        public IActionResult Products()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

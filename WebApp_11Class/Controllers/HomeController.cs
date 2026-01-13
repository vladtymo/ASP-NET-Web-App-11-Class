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
            new Product { Id = 1, Title = "Laptop", Category = "Electronics", Price = 1200, Quantity = 10, ImageUrl = "https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTA5L3Jhd3BpeGVsX29mZmljZV8zMV9waG90b19vZl9hX2xhcHRvcF9tb2NrdXBfY2xvc2UtdXBfbWluaW1hbF9pc182M2Q2NzViOS00YjlhLTQ3OWEtOGMyMS1hYWQwMjViNWYzZDIucG5n.png" },
            new Product { Id = 2, Title = "Desk Chair", Category = "Furniture", Price = 150, Quantity = 25, ImageUrl = "https://m.media-amazon.com/images/I/61VqPRU2-UL._AC_UF894,1000_QL80_.jpg" },
            new Product { Id = 3, Title = "Notebook", Category = "Stationery", Price = 5, Quantity = 100 },
            new Product { Id = 4, Title = "Smartphone", Category = "Electronics", Price = 800, Quantity = 15, ImageUrl="https://cdn.thewirecutter.com/wp-content/media/2025/09/BG-IPHONE-2048px_IPHONE-17-PRO-MAX_BACK.jpg?auto=webp&quality=75&width=1024" },
            new Product { Id = 5, Title = "Coffee Mug", Category = "Kitchenware", Price = 12, Quantity = 50 }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult AddFavorite(int id)
        {
            HttpContext.Session.SetInt32("FavoriteProductId", id);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            ViewBag.FavId = HttpContext.Session.GetInt32("FavoriteProductId");
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var item = products.FirstOrDefault(x => x.Id == id);
            return View(item);
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

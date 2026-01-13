using Microsoft.AspNetCore.Mvc;
using WebApp_11Class.Models;

namespace WebApp_11Class.Controllers
{
    public class CategoriesController : Controller
    {
        static List<Category> categories = new()
        {
            new Category { Id = 1, Name = "Electroniucs" },
            new Category { Id = 2, Name = "Sport" },
            new Category { Id = 3, Name = "Food & Drinks" },
        };

        public IActionResult Index()
        {
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var item = categories.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound(); // 404

            return View(item);
        }

        [HttpPost]
        public IActionResult SaveNew(Category element)
        {
            categories.Add(element);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Category element)
        {
            var index = categories.FindIndex(x => x.Id == element.Id);
            categories[index] = element;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // delete logic
            var item = categories.Find(x => x.Id == id);

            if (item == null)
                return NotFound(); // 404

            categories.Remove(item);

            return RedirectToAction("Index");
        }
    }
}

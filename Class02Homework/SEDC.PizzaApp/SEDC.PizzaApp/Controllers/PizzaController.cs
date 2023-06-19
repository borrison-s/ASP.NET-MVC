using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetAllPizzas()
        {
            List<Pizza> pizzaDb = StaticDb.Pizzas;
            return View(pizzaDb);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(pizza);
        }
    }
}

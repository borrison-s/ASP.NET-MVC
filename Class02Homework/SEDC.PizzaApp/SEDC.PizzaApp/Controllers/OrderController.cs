using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("ListOrders")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            Order order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(order);
        }

        public IActionResult JsonData()
        {
            Order order = new Order
            {
                Id = 3,
                Price = 700
            };

            return new JsonResult(order);
        }

        public IActionResult RedirectToHomeIndex()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}

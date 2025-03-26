using System;
using System.Web.Mvc;
using BudgetHotel.Models;

namespace BudgetHotel.Controllers
{
    public class BookingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(GuestBooking model)
        {
            if (ModelState.IsValid)
            {
                return View("Result", model); // Pass model to the result view
            }

            return View("Index", model); // Stay on form if validation fails
        }
    }
}

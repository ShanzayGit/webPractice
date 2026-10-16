using Microsoft.AspNetCore.Mvc;
using web_hw_04.Models;

namespace web_hw_04.Controllers
{
    public class CarsController : Controller
    {
        private static List<car> availableCars = new List<car>{ new car {Id= 1, Name="Alto", PricePerDay=3000 },
            new car{Id=2,Name="Corolla", PricePerDay=6000 },new car{Id=3,Name="Civic", PricePerDay=8000 } };
        private static List<car> bookedCars = new List<car>();

        [HttpGet]
        public IActionResult Index()
        {

            return View(availableCars);
        }

        [HttpPost]
        public IActionResult Book(int id)
        {
            car? temp = null;
            foreach (car car in availableCars)
            {
                if (car.Id == id)
                {
                    temp = car;
                    break;
                }
            }
            if (temp != null)
            {
                availableCars.Remove(temp);
                bookedCars.Add(temp);
                return RedirectToAction("Booked");
            }
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Booked() 
        {
            return View(bookedCars);
        }


    }
}

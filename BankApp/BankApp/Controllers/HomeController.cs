using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void OnPost()
        {
            Console.WriteLine("asdasdsadasdadasd");
        }
    }
}

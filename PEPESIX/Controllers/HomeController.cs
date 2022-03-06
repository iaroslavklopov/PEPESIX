using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using PEPESIX.Models;

namespace PEPESIX.Controllers
{
    public class Book
    {

        public string Name;
        public string Avtor;
        public string Year;
        public Book(string Name, string Avtor, string Year)
        {
            this.Name = Name;
            this.Avtor = Avtor;
            this.Year = Year;
        }
    }
    public class Library
    {
        public static List<Book> Biblioteka = new List<Book>();
        public Library()
        {

        }
        public static void AddBook(string Name, string Avtor, string Year)
        {
            Biblioteka.Add(new Book(Name, Avtor, Year));
        }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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
        public int _counter = 0;
        public IActionResult TaskFirst()
        {
            return View();
        }
        public IActionResult TaskSecond()
        {
            return View();
        }
        public IActionResult TaskThird()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskFirst(string FirstN, string SecondN, string ThirdN)
        {
            ViewBag.H = (Convert.ToDouble(FirstN) + Convert.ToDouble(SecondN) + Convert.ToDouble(ThirdN)) / 3;
            return View();
        }
        [HttpPost]
        public IActionResult TaskSecond(string Predlozhenie)
        {
            ViewBag.S = Predlozhenie.Replace(' ', '_');
            return View();
        }
        [HttpPost]
        public IActionResult TaskThird(string Nazvanie, string Avtor, string Year, string fn, string fa, string fy)
        {
            Library.AddBook(Nazvanie, Avtor, Year);
            for (int i = 0; i < Library.Biblioteka.Count; i++)
            {
                if (fn == Library.Biblioteka[i].Name)
                {
                    ViewBag.N = Library.Biblioteka[i].Name + ", ";
                    ViewBag.A = Library.Biblioteka[i].Avtor + ", ";
                    ViewBag.Y = Library.Biblioteka[i].Year + " ";
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
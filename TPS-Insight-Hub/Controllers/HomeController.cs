using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TPS_Insight_Hub.Models.Repository;

namespace TPS_Insight_Hub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public HomeController(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewPost()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        public IActionResult Tickets()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        

        public IActionResult ViewTicket()
        {
            return View();
        }


    }
}

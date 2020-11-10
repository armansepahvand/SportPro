using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;


namespace SportsPro.Controllers
{
    //Home Controller
    public class HomeController : Controller
    {
        private IProductRepository productRepository;

        public HomeController(IProductRepository _repository)
        {
            this.productRepository = _repository;
        }

        //Get method for the index
        public IActionResult Index()
        {
            return View();
        }

        //Get method for the about view
        [Route("/About/")]
        public IActionResult About() => View();

        //Get method for the unit testing for the add product
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Product());
        }

        //Get method for the edit view
        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            return View("Edit", new Product());
        }

        //Get method for the list view
        public ViewResult List()
        {
            ViewBag.Action = "List";
            return View("list");
        }

        //Get method for the delete view
        public ViewResult Delete()
        {
            ViewBag.Action = "Delete";
            return View("Delete");
        }
    }

}
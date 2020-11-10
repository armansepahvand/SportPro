using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    //Product Controller
    public class ProductController : Controller
    {

        private SportsProContext context { get; set; }

        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }

        //Get method for the list view
        [Route("/Products/")]
        public ViewResult List()
        {
            var products = context.Products.OrderBy(m => m.Name).ToList();
            return View("list", products);
        }

        //Get method for the edit view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Product());
        }

        //Get method for the edit view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        //Post method redirecting to the list view
        [HttpPost]
        public RedirectToActionResult Edit(Product product)
        {
            if (product.ProductID == 0)
            {
                TempData["AddMessage"] = product.Name + " was Added";
                context.Products.Add(product);
            }
            else

                context.Products.Update(product);
            context.SaveChanges();
            TempData["EditMessage"] = product.Name + " was Edited";
            return RedirectToAction("List", "Product");

        }

        //Get method for the delete view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products.Find(id);
            TempData["oldName"] = product.Name;
            return View(product);
        }

        //Post method redirecting to the list
        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            TempData["DeleteMessage"] = TempData["oldName"] + " was deleted";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}

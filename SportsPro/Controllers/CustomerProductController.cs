using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;

namespace SportsPro.Controllers
{
    //Controller for a many to many customer-product table
    [Authorize(Roles = "Admin")]
    public class CustomerProductController : Controller
    {
        private SportProUnitOfWork data { get; set; }
        public CustomerProductController(SportsProContext ctx) => data = new SportProUnitOfWork(ctx);

        //Get method for customers
        public IActionResult getcustomer()
        {
            var customerOptions = new QueryOptions<Customer> { };
            customerOptions.OrderBy = g => g.FirstName;
            var customers = new CustomerProductViewModel
            {
                Customers = data.Customers.List(customerOptions).ToList(),
                CurrentCustomer = new Customer()
            };
            ViewBag.Current = new Customer();

            return View(customers);
        }

        //Get method for the list view
        [HttpGet]
        public IActionResult listget(int id)
        {
            var productOptions = new QueryOptions<CustomerProduct>
            {
                Includes = "Customer, Product",

            };
            productOptions.Where = g => g.CustomerId == id;

            var pOptions = new QueryOptions<Product> { };
            pOptions.OrderBy = g => g.Name;


            var cOption = new QueryOptions<Customer> { };
            cOption.Where = g => g.CustomerID == id;


            var products = new CustomerProductViewModel
            {
                CustomerProducts = data.CustomerProducts.List(productOptions).ToList(),
                Products = data.Products.List(pOptions).ToList(),
                CurrentCustomer=data.Customers.Get(cOption)
            };

            ViewBag.Current = data.Customers.Get(cOption).FullName; 


            return View("list", products);
        }

        //Post method for the list view
        [HttpPost]
        public IActionResult list(CustomerProductViewModel prod)
        {
            var productOptions = new QueryOptions<CustomerProduct>
            {
                Includes = "Customer, Product",

            };
            productOptions.Where = g => g.CustomerId == prod.CurrentCustomer.CustomerID;

            var pOptions = new QueryOptions<Product> { };
            pOptions.OrderBy = g => g.Name;
            var products = new CustomerProductViewModel {
                CustomerProducts = data.CustomerProducts.List(productOptions).ToList(),
                Products = data.Products.List(pOptions).ToList()
            };
           
            var cOption= new QueryOptions<Customer> { };
            cOption.Where = g=> g.CustomerID== prod.CurrentCustomer.CustomerID;
            ViewBag.Current = data.Customers.Get(cOption).FullName;


            return View(products);
        }

        //Post method redirecting to the listget method
        [HttpPost]
        public RedirectToActionResult Add(CustomerProductViewModel customerproduct)
        {
            var NCustomerProduct = new CustomerProduct();
            NCustomerProduct.CustomerId = customerproduct.CurrentCustomer.CustomerID;
            NCustomerProduct.ProductId = customerproduct.CurrentProduct.ProductID;
            
            try
            {
                data.CustomerProducts.Insert(NCustomerProduct);
                data.Save();
                TempData.Clear();
            }
            catch{
                TempData["Error"] = "Please select a product that is not selected";

            }
     
            int ID = NCustomerProduct.CustomerId;
            return RedirectToAction("listget", new {id = ID } );
        }

        //Get method for the delete view
        [HttpGet]
        public IActionResult Delete(int id, int slug)
        {
            var productOptions = new QueryOptions<CustomerProduct>
            {
                Includes = "Customer, Product",

            };
            productOptions.Where = g => g.ProductId == id;
            productOptions.Where = g => g.CustomerId == slug;

            var customerproduct = new CustomerProductViewModel
            {
                CurrentCustomerProduct = data.CustomerProducts.Get(productOptions)
            };

            return View(customerproduct);
        }

        //Post method for the delete view
        [HttpPost]
        public IActionResult Delete(CustomerProductViewModel customerproduct)
        {
            int cid = customerproduct.CurrentCustomerProduct.CustomerId;
            int pid = customerproduct.CurrentCustomerProduct.ProductId;
            var deletCP = new CustomerProduct();
            deletCP = customerproduct.CurrentCustomerProduct;
            data.CustomerProducts.Delete(deletCP);
            data.Save();
            return RedirectToAction("Listget", new { id = cid }  );
        }
    }
}

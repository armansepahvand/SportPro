using SportsPro.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    //View model for customer-product class to transfer data from controller to the view
    public class CustomerProductViewModel
    {
        private List<Customer> customers;
        public List<Customer> Customers
        {
            get => customers;
            set
            {
                customers = new List<Customer>();
                customers.AddRange(value);
            }
        }

       
        private List<Product> products;
        public List<Product> Products
        {
            get => products;
            set
            {
                products = new List<Product>();
                products.AddRange(value);
            }
        }

        private List<CustomerProduct> customerproducts;
        public List<CustomerProduct> CustomerProducts
        {
            get => customerproducts;
            set
            {
                customerproducts = new List<CustomerProduct>();
                customerproducts.AddRange(value);
            }
        }

        public Customer CurrentCustomer { get; set; }
        public Product CurrentProduct { get; set; }

        public CustomerProduct CurrentCustomerProduct { get; set; }

        public List<Product> CurrentProducts { get; set; }       
        public string Mode { get; set; }

    }
}

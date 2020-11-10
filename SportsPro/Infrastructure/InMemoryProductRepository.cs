using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Infrastructure
{
    //interface for the productmemory repository
    public class InMemoryProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();

        public object Product { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Product GetProductById(int id)
        {
            return products.Where(p => p.ProductID == id).FirstOrDefault();
        }

        public List<Product> ListProducts()
        {
            return products;
        }
    }
}


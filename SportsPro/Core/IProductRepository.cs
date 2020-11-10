using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro
{
    //interface for the productrepository 
    public interface IProductRepository
    {
        object Product { get; set; }

        List<Product> ListProducts();
        Product GetProductById(int id);
    }
}

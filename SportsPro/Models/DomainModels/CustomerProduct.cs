using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models.DomainModels
{
    public class CustomerProduct
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}

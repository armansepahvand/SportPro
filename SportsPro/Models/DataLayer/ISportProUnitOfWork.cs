using SportsPro.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models.DataLayer
{
    public interface ISportProUnitOfWork
    {
        Repository<Country> Countries { get; }
        Repository<Customer> Customers { get; }
        Repository<Incident> Incidents { get; }
        Repository<Product> Products { get; }
        Repository<Technician> Technicians { get; }

        Repository<CustomerProduct> CustomerProducts { get; }
        void Save();
    }
}

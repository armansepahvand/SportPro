
using SportsPro.Models.DomainModels;

namespace SportsPro.Models.DataLayer
{
    public class SportProUnitOfWork : ISportProUnitOfWork
    {
        private SportsProContext context { get; set; }
        public SportProUnitOfWork(SportsProContext ctx) => context = ctx;

        private Repository<Country> countryData;
        public Repository<Country> Countries
        {
            get
            {
                if (countryData == null)
                    countryData = new Repository<Country>(context);
                return countryData;
            }
        }

        private Repository<Customer> customerData;
        public Repository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }

        private Repository<Incident> IncidentData;
        public Repository<Incident> Incidents
        {
            get
            {
                if (IncidentData == null)
                    IncidentData = new Repository<Incident>(context);
                return IncidentData;
            }
        }

        private Repository<Product> productData;
        public Repository<Product> Products
        {
            get
            {
                if (productData == null)
                    productData = new Repository<Product>(context);
                return productData;
            }
        }

        private Repository<Technician> technicianData;
        public Repository<Technician> Technicians
        {
            get
            {
                if (technicianData == null)
                    technicianData = new Repository<Technician>(context);
                return technicianData;
            }
        }

        private Repository<CustomerProduct> CustomerProductData;
        public Repository<CustomerProduct> CustomerProducts
        {
            get
            {
                if (CustomerProductData == null)
                    CustomerProductData = new Repository<CustomerProduct>(context);
                return CustomerProductData;
            }
        }


        public void Save() => context.SaveChanges();
    }
}

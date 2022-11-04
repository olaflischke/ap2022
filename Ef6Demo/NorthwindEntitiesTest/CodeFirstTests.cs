using Ef6CodeFirst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace NorthwindEntitiesTest
{
    [TestClass]
    public class CodeFirstTests
    {
        NorthwindEntities northwindContext = new NorthwindEntities();

        [TestMethod]
        public void GetCustomers()
        {
            var germans = northwindContext.Customers.Where(cu => cu.Country == "Germany");

            foreach (Customer item in germans)
            {
                Console.WriteLine($"{item.CompanyName}: {item.Orders.Count}");
            }

            var c = northwindContext.Customers.Select(cu => new { cu.CompanyName, cu.ContactName });


        }

        [TestMethod]
        public void ChangeCustomer()
        {
            using (NorthwindEntities northwindContext = new NorthwindEntities())
            {
                Customer alfki = northwindContext.Customers.Find("ALFKI");

                alfki.ContactName = "Maria Schmitt";

                northwindContext.ChangeTracker.Entries<Customer>().Where(e => e.State == System.Data.Entity.EntityState.Modified);

                Customer fissa = northwindContext.Customers.Find("FISSA");

                northwindContext.Customers.Remove(fissa);

                northwindContext.Entry(fissa).State = System.Data.Entity.EntityState.Unchanged;

                northwindContext.SaveChanges();
            }
        }
    }
}

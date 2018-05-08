using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_PersonManager.Models;

namespace WebAPI_PersonManager.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ManagerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.PersonItems.Any())
            {
                return;   // DB has been seeded
            }

            var persons = new Person[]
            {
                    new Person { FirstName = "Item",LastName="1",Address="haNoi",Birthday= DateTime.Parse("2005-09-01"), Sex="Nam"},
                    new Person { FirstName = "Item", LastName = "2", Address = "haNoi", Birthday = DateTime.Parse("2015-09-01"), Sex = "Nữ"}

            };
            foreach (Person s in persons)
            {
                context.PersonItems.Add(s);
            }
            context.SaveChanges();


        }
    }
}

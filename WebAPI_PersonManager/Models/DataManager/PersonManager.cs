using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_PersonManager.Models.Repository;

namespace WebAPI_PersonManager.Models.DataManager
{
    public class PersonManager: IDataRepository<Person, long>
    {
        ManagerContext ctx;
        public PersonManager(ManagerContext c)
        {
            ctx = c;
        }

        public Person Get(long id)
        {
            var person = ctx.PersonItems.FirstOrDefault(b => b.Id == id);
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            var persons = ctx.PersonItems.ToList();
            return persons;
        }

        public long Add(Person stundent)
        {
            ctx.PersonItems.Add(stundent);
            long personID = ctx.SaveChanges();
            return personID;
        }

        public long Delete(long id)
        {
            int personID = 0;
            var person = ctx.PersonItems.FirstOrDefault(b => b.Id == id);
            if (person != null)
            {
                ctx.PersonItems.Remove(person);
                personID = ctx.SaveChanges();
            }
            return personID;
        }

        public long Update(long id, Person item)
        {
            long Perid = 0;
            var person = ctx.PersonItems.Find(id);
            if (person != null)
            {
                person.FirstName = item.FirstName;
                person.LastName = item.LastName;
                person.Birthday = item.Birthday;
                person.Address = item.Address;
                person.Sex = item.Sex;

                Perid = ctx.SaveChanges();
            }
            return Perid;
        }
    }

}

using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AddressDbContext addressDbContext;

        public PersonRepository( AddressDbContext addressDbContext)
        {
            this.addressDbContext = addressDbContext;
        }
        public async Task<Person> AddPerson(Person person)
        {
            var result = await addressDbContext.Person.AddAsync(person);
            await addressDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> DeletePerson(int PersonID)
        {
            var results = await addressDbContext.Person
                .FirstOrDefaultAsync(p => p.PersonID == PersonID);
            if(results != null)
            {
                addressDbContext.Person.Remove(results);
                await addressDbContext.SaveChangesAsync();

                return results;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await addressDbContext.Person.ToListAsync();
        }
        
        public async Task<Person> GetPersonByEmail(string email)
        {
            return await addressDbContext.Person
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Person> GetPerson(int id)
        {
            return await addressDbContext.Person
                .Include(e => e.Suburb)
                .FirstOrDefaultAsync(p => p.PersonID == id);
        }
        public async Task<Person> UpdatePerson(Person person)
        {
            var result = await addressDbContext.Person
                .FirstOrDefaultAsync(p => p.PersonID == person.PersonID);

            if(result != null)
            {
                result.FirstName = person.FirstName;
                result.LastName = person.LastName;
                result.PhoneNumber = person.PhoneNumber;
                result.Email = person.Email;
                result.AddressLine1 = person.AddressLine1;
                result.AddressLine2 = person.AddressLine2;
                result.SuburbID = person.SuburbID;

                await addressDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

       
        public async Task<IEnumerable<Person>> Search(string name)
        {
            IQueryable<Person> query = addressDbContext.Person;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}

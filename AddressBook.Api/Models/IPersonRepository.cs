using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<IEnumerable<Person>> Search(string name);
        Task<Person> GetPerson(int id);
        Task<Person> AddPerson(Person person);
        Task<Person> GetPersonByEmail(string email);
        Task<Person> UpdatePerson(Person person);
        Task<Person> DeletePerson(int PersonID);
        
    }
}

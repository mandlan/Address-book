using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.App.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(int id);
        Task<Person> UpdatePerson(Person updatePerson);
        Task DeletePerson(int id);
        Task UpdatePeople(Person person);
        Task<Person> AddPerson(Person person);
        Task<IEnumerable<Person>> Search(string search);
    }
}

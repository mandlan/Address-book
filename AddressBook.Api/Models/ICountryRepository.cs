using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int CountryID);
        Task<IEnumerable<Country>> Search(string name);
        Task<Country> AddCountry(Country country);
        //Task<Country> DeteCountry(Country country);

    }
}

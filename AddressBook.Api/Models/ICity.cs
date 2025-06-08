using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public interface ICity
    {
        Task<IEnumerable<City>> GetCities();
        Task<City> AddCity(City city);
    }
}

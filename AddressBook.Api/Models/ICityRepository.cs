using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCities();
        Task<City> GetCity(int id);
        Task<IEnumerable<City>> Search(string name);
        Task<City> AddCity(City city);
        Task<City> DeleteCity(int CityID);
    }
}

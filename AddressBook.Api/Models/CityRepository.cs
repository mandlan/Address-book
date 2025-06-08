using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public class CityRepository : ICityRepository
    {
        private readonly AddressDbContext addressDbContext;

        public CityRepository(AddressDbContext addressDbContext)
        {
            this.addressDbContext = addressDbContext;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await addressDbContext.City.ToListAsync();
        }
        public async Task<City> GetCity(int id)
        {
            return await addressDbContext.City
                .FirstOrDefaultAsync(c => c.CityID == id);
        }
        public async Task<City> AddCity(City city)
        {
            var result = await addressDbContext.City.AddAsync(city);
            await addressDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<City> DeleteCity(int CityID)
        {
            var result = await addressDbContext.City
                .FirstOrDefaultAsync(c => c.CityID == CityID);
            if(result != null)
            {
                addressDbContext.City.Remove(result);
                await addressDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<IEnumerable<City>> Search(string name)
        {
            IQueryable<City> query = addressDbContext.City;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.CityName.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}

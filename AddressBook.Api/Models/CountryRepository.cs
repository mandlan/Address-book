using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AddressDbContext addressDbContext;

        public CountryRepository(AddressDbContext addressDbContext)
        {
            this.addressDbContext = addressDbContext;
        }

        public async Task<Country> GetCountry(int CountryID)
        {
            return await addressDbContext.Country
                .FirstOrDefaultAsync(c => c.CountryID == CountryID);
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await addressDbContext.Country.ToListAsync();
        }
        public async Task<Country> AddCountry(Country country)
        {
            var result = await addressDbContext.Country.AddAsync(country);
            await addressDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Country>> Search(string name)
        {
            IQueryable<Country> query = addressDbContext.Country;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.CountryName.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}

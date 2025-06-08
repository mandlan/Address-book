using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public class SuburbRepository : ISuburbRepository
    {
        private readonly AddressDbContext addressDbContext;

        public SuburbRepository(AddressDbContext addressDbContext)
        {
            this.addressDbContext = addressDbContext;
        }

       public async Task<IEnumerable<Suburb>> GetSuburbs()
        {
            return await addressDbContext.Suburb.ToListAsync();
        }

        public async Task<Suburb> GetSuburb(int subID)
        {
            return await addressDbContext.Suburb
                .FirstOrDefaultAsync(s => s.SuburbID == subID);
        }

        public async Task<Suburb> AddSuburb(Suburb suburb)
        {
            var results = await addressDbContext.Suburb.AddAsync(suburb);
            await addressDbContext.SaveChangesAsync();
            return results.Entity;
        }
        public async Task<Suburb> DeleteSuburb(int SuburbID)
        {
            var results = await addressDbContext.Suburb
                .FirstOrDefaultAsync(s => s.SuburbID == SuburbID);

            if(results != null)
            {
                addressDbContext.Suburb.Remove(results);
                await addressDbContext.SaveChangesAsync();

                return results;
            }
            return null;
        }
    }
}

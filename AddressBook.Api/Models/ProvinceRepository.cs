using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly AddressDbContext addressDbContext;

        public ProvinceRepository(AddressDbContext addressDbContext)
        {
            this.addressDbContext = addressDbContext;
        }

        public async Task<IEnumerable<Province>> GetProvinces()
        {
            return await addressDbContext.Province.ToListAsync();
        }
        public async Task<Province> GetProvince(int id)
        {
            return await addressDbContext.Province
                .FirstOrDefaultAsync(p => p.ProvinceID == id);
        }
        public async Task<Province> AddProvince(Province province)
        {
            var result = await addressDbContext.Province.AddAsync(province);
            await addressDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<IEnumerable<Province>> Search(string name)
        {
            IQueryable<Province> query = addressDbContext.Province;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Province> DeleteProvince(int ProvinceID)
        {
            var result = await addressDbContext.Province
                .FirstOrDefaultAsync(p => p.ProvinceID == ProvinceID);
            if(result != null)
            {
                addressDbContext.Province.Remove(result);
                await addressDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}

using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> GetProvinces();
        Task<IEnumerable<Province>> Search(string name);
        Task<Province> GetProvince(int id);
        Task<Province> AddProvince(Province province);
        Task<Province> DeleteProvince(int ProvinceID);

    }
}

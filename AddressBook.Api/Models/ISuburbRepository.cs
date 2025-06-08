using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Models
{
    public interface ISuburbRepository
    {

        Task<IEnumerable<Suburb>> GetSuburbs();
        Task<Suburb> GetSuburb(int subID);
        Task<Suburb> AddSuburb(Suburb suburb);
        //Task<Suburb> UpdateSuburb(Suburb suburb);
        Task<Suburb> DeleteSuburb(int SuburbID);

    }
}

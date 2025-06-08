using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.App.Services
{
    public interface ISuburbService
    {
        Task<IEnumerable<Suburb>> GetSuburbs();
    }
}

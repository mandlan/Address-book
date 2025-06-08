using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Suburb
    {
        public int SuburbID { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
    }
}

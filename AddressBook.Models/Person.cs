using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public int SuburbID { get; set; }
        public Suburb Suburb { get; set; }
       


    }
}

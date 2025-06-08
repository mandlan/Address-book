using AddressBook.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using AddressBook.App.Services;

namespace AddressBook.App.Pages
{
    public class AddPersonBase : ComponentBase
    {
        [Inject]
        public IPersonService PersonService { get; set; }
        public Person Person { get; set; } = new Person();
        public Suburb Suburb { get; set; } = new Suburb();
        protected bool Saved;
        protected string Message = string.Empty;
        public List<Suburb> Suburbs { get; set; } = new List<Suburb>();
        [Inject]
        public ISuburbService SuburbService { get; set; }
       
        public string Id { get; set; }

        public NavigationManager NavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Suburbs = (await SuburbService.GetSuburbs()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            if (String.IsNullOrEmpty(Id))
            {
                var res = await PersonService.AddPerson(Person);

                if(res != null)
                {
                    Saved = true;
                    Message = "Person has been added";
                    
                }
                else
                {
                     Message = "Something went wrong";
                }
            }
            else
            {
                Message = "You can't add an empty data";
            }
            
        }
    }
}

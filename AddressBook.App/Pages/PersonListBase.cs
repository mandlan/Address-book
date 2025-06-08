using AddressBook.App.Services;
using AddressBook.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AddressBook.App.Pages
{
    
    public class PersonListBase : ComponentBase
    {
        [Inject]
        public ISuburbService SuburbService { get; set; }
        public List<Suburb> Suburbs { get; set; } = new List<Suburb>();
        [Inject]
        public IPersonService PersonService { get; set; }
        public IEnumerable<Person> People { get; set; }

        public Person Person { get; set; } = new Person();
        public Suburb Suburb { get; set; } = new Suburb();

        public string ID { get; set; }
        
        public NavigationManager NavigationManager { get; set; }
        protected string Message = string.Empty;
        protected bool Saved;
        protected override async Task OnInitializedAsync()
        {
           Suburbs = (await SuburbService.GetSuburbs()).ToList();
           People = (await PersonService.GetPeople()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            if (String.IsNullOrEmpty(ID))
            {
                var res = await PersonService.AddPerson(Person);

                if (res != null)
                {
                    Saved = true;
                    Message = "Person has been added";
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
        }
        protected async Task Delete_Click()
        {
            if (!String.IsNullOrEmpty(ID))
            {
                var personID = Convert.ToInt32(ID);
                await PersonService.DeletePerson(personID);
                NavigationManager.NavigateTo("/");

            }

            Message = "Something went wrong, unable to delete";
        }
    }
}

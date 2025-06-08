using AddressBook.App.Services;
using AddressBook.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.App.Pages
{
    public class PersonDetailsBase : ComponentBase
    {
        public Person Person { get; set; } = new Person();
        public Suburb Suburb { get; set; } = new Suburb();

        [Inject]
        public IPersonService PersonService { get; set; }

        [Parameter]
        public string ID { get; set; }
        public NavigationManager NavigationManager { get; set; }
        protected string Message = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            ID = ID ?? "2";
            Person = await PersonService.GetPerson(int.Parse(ID));
           
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

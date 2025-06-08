using AddressBook.App.Services;
using AddressBook.Models;
using AddressBook.App.Models;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace AddressBook.App.Pages
{
    public class EditPersonBase : ComponentBase
    {
        
        Person person = new Person();
        //private readonly HttpClient httpClient;
        [Inject]
        public IPersonService PersonService { get; set; }
        public Person Person { get; set; } = new Person();
        public EditPersonModel EditPersonModel { get; set; } = new EditPersonModel();

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public string Id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected bool Saved;
        protected string Message = string.Empty;
        protected async override Task OnInitializedAsync()
        {
            Person = await PersonService.GetPerson(int.Parse(Id));
            Mapper.Map(Person, EditPersonModel);
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
                await PersonService.UpdatePeople(Person);
                Saved = true;
                Message = "Person details has been updated";
            }
            NavigationManager.NavigateTo("/");
        }

        protected async Task Delete_Click()
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var personID = Convert.ToInt32(Id);
                await PersonService.DeletePerson(personID);
                NavigationManager.NavigateTo("/");

            }

            Message = "Something went wrong, unable to delete";
        }
    }
}

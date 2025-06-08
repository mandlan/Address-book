using AddressBook.App.Services;
using AddressBook.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.App.Pages
{
    public class ViewSuburbBase : ComponentBase
    {
        [Inject]
        public ISuburbService SuburbService { get; set; }

        public List<Suburb> Suburbs { get; set; } = new List<Suburb>();

        private Suburb Suburb { get; set; } = new Suburb();
        protected override async Task OnInitializedAsync()
        {
            Suburbs = (await SuburbService.GetSuburbs()).ToList();
        }
    }
}

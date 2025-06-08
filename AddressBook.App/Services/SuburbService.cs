using AddressBook.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AddressBook.App.Services
{
    public class SuburbService : ISuburbService
    {
        private readonly HttpClient httpClient;

        public SuburbService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Suburb>> GetSuburbs()
        {
            var response = await httpClient.GetStreamAsync($"api/Suburb");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Suburb>>
                (response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}

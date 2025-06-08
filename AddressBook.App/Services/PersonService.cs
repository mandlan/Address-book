using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using AddressBook.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;


namespace AddressBook.App.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient httpClient;

        public PersonService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            
            return await httpClient.GetJsonAsync<Person[]>("api/Person");
        }
        public async Task<IEnumerable<Person>> Search(string search)
        {
            return await httpClient.GetJsonAsync<Person[]>($"/api/Person/{search}");
        }

        public async Task<Person> GetPerson(int id)
        {
            return await httpClient.GetJsonAsync<Person>($"/api/Person/{id}");
        }
        public async Task<Person> UpdatePerson(Person updatePerson)
        {
            return await httpClient.PutJsonAsync<Person>($"/api/Person", updatePerson);

           
        }

        public async Task UpdatePeople(Person person)
        {
            try
            {
                var jsonString = new StringContent (System.Text.Json.JsonSerializer.Serialize(person), Encoding.UTF8, "application/json");

                var url = $"api/Person/{person.PersonID}";

                var response = await httpClient.PutAsync(url, jsonString);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeletePerson(int id)
        {
            try
            {
                await httpClient.DeleteAsync($"api/Person/{id}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Person> AddPerson(Person person)
        {

            return await httpClient.PostJsonAsync<Person>("api/Person", person);
               //var jsonString = new StringContent(System.Text.Json.JsonSerializer.Serialize(person), Encoding.UTF8, "applicatiol/json");

                //return await httpClient.PostAsJsonAsync<Person>("api/Person", person);

                //if (response.IsSuccessStatusCode)
                //{
                //    var responseBody = await response.Content.ReadAsStreamAsync();

                //    return await System.Text.Json.JsonSerializer.DeserializeAsync<Person>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                //}

                //return response;
            
        }
    }
}

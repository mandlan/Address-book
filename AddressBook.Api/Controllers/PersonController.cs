using AddressBook.Api.Models;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;
       
        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetPeople()
        {
            try
            {
                return Ok(await personRepository.GetPeople());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            try
            {
                var result = await personRepository.GetPerson(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreatePerson(Person person)
        {
            try
            {
                if(person == null)
                {
                    return BadRequest();
                }

                //var per = personRepository.GetPersonByEmail(person.Email);

                //if (per != null)
                //{
                //    ModelState.AddModelError("email", "The email is already in use");
                //    return BadRequest(ModelState);
                //}

                var createPerson = await personRepository.AddPerson(person);

                return CreatedAtAction(nameof(GetPerson), new { id = createPerson.PersonID }, createPerson);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person person)
        {
            try
            {
                if(id != person.PersonID)
                {
                    return BadRequest("Person ID mismatch");
                }

                var personToUpdate = await personRepository.GetPerson(id);

                if(personToUpdate == null)
                {
                    return NotFound($"Person with id {id} not found");
                }

                return await personRepository.UpdatePerson(person);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpGet("{search}")]

        public async Task<ActionResult<IEnumerable<Person>>> Search(string name)
        {
            try
            {
                var result = await personRepository.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var personToDelete = personRepository.GetPerson(id);

                if(personToDelete == null)
                {
                    return NotFound($"Person with ID = {id} not found");
                }

                return await personRepository.DeletePerson(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        
    }
}

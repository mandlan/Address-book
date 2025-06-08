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
    public class SuburbController : ControllerBase
    {
        private readonly ISuburbRepository suburbRepository;

        public SuburbController(ISuburbRepository suburbRepository)
        {
            this.suburbRepository = suburbRepository;
        }

       [HttpGet]

       public async Task<ActionResult> GetSuburbs()
        {
            try
            {
                return Ok(await suburbRepository.GetSuburbs());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet ("{id:int}")]
        public async Task<ActionResult<Suburb>> GetSuburb(int id)
        {
            try
            {
                var result = await suburbRepository.GetSuburb(id);

                if (result == null) return NotFound();

                return result;
               
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateSuburb(Suburb suburb)
        {
            try
            {
                if(suburb == null)
                {
                    return BadRequest();
                }

                var createSuburb = await suburbRepository.AddSuburb(suburb);
                return CreatedAtAction(nameof(GetSuburb), new { id = createSuburb.SuburbID }, createSuburb);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete ("{id:int}")]
        public async Task<ActionResult<Suburb>> DeleteSuburb(int id)
        {
            try
            {
                var deleteSuburb = suburbRepository.GetSuburb(id);

                if(deleteSuburb == null)
                {
                    return NotFound($"Suburb with ID = {id} not found");
                }

                return await suburbRepository.DeleteSuburb(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}

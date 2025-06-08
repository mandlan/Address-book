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
    public class cityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        public cityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            try
            {
                return (await cityRepository.GetCities()).ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet ("{id:int}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            try
            {
                var result = await cityRepository.GetCity(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCity(City city)
        {
            try
            {
                if(city == null)
                {
                    return BadRequest();
                }

                var createCity = await cityRepository.AddCity(city);

                return CreatedAtAction(nameof(GetCity), new { id = createCity }, createCity);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpDelete ("{id:int}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            try
            {
                var deleteCity = cityRepository.GetCity(id);

                if(deleteCity == null)
                {
                    return NotFound($"City with ID = {id} not found");
                }

                return await cityRepository.DeleteCity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<City>>> Search(string name)
        {
            try
            {
                var result = await cityRepository.Search(name);

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
    }
}

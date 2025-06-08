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
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceRepository provinceRepository;

        public ProvinceController(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProvinces()
        {
            try
            {
                return Ok(await provinceRepository.GetProvinces());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Province>> GetProvince(int id)
        {
            try
            {
                var result = await provinceRepository.GetProvince(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<Province>> Search(string name)
        {
            try
            {
                var result = await provinceRepository.Search(name);

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
        [HttpPost]

        public async Task<ActionResult> CreateProvince(Province province)
        {
            try
            {
                if(province == null)
                {
                    return BadRequest();
                }

                var createProvince = await provinceRepository.AddProvince(province);

                return CreatedAtAction(nameof(GetProvince), new { id = createProvince }, createProvince);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Province>> DeleteProvince(int id)
        {
            try
            {
                var deleteProvince = provinceRepository.GetProvince(id);

                if (deleteProvince == null)
                {
                    return NotFound($"Province with ID = {id} not found");
                }

                return await provinceRepository.DeleteProvince(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}

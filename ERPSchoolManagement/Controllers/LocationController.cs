using ERPSchoolManagement.Models.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ERPSchoolManagement.Interface;

namespace ERPSchoolManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocation _location;

        public LocationController(ILocation location)
        {
            _location = location;
        }

        [HttpPost("States")]
        public async Task<ActionResult<IEnumerable<CustomState>>> GetStates()
        {
            var _states = await _location.GetStates();
            return Ok(_states);
        }

        [HttpPost("Cities")]
        public async Task<ActionResult<IEnumerable<CustomCity>>> GetCities([FromBody] int stateId)
        {
            var _cities = await _location.GetCities(stateId);
            return Ok(_cities);
        }

        [HttpPost("Localities")]
        public async Task<ActionResult<IEnumerable<CustomLocality>>> GetLocalities([FromBody] Int64 cityId)
        {
            var _states = await _location.GetLocalities(cityId);
            return Ok(_states);
        }

        [HttpPost("State/Add")]
        public async Task<ActionResult<bool>> AddState(CustomState state)
        {
            var result = await _location.AddState(state);
            return Ok(result);
        }

        [HttpPost("City/Add")]
        public async Task<ActionResult<bool>> AddCity(CustomCity city)
        {
            var result = await _location.AddCity(city);
            return Ok(result);
        }

        [HttpPost("Locality/Add")]
        public async Task<ActionResult<bool>> AddLocality(CustomLocality locality)
        {
            var result = await _location.AddLocality(locality);
            return Ok(result);
        }

    }
}

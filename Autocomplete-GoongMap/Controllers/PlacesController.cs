﻿using GoongService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autocomplete_GoongMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly GoongMapService _goongMapService;

        public PlacesController(GoongMapService goongMapService)
        {
            _goongMapService = goongMapService;
        }

        [HttpGet("autocomplete")]
        public async Task<IActionResult> Autocomplete([FromQuery] string query, [FromQuery] int? limit, [FromQuery] int? radius, [FromQuery] bool moreCompound = false)
        {
            try
            {
                var results = await _goongMapService.GetAutocompleteResults(query, limit, radius, moreCompound);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("forward-geocode")]
        public async Task<IActionResult> ForwardGeocode([FromQuery] string address)
        {
            try
            {
                var results = await _goongMapService.ForwardGeocode(address);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("reverse-geocode")]
        public async Task<IActionResult> ReverseGeocode([FromQuery] string latlng)
        {
            try
            {
                var results = await _goongMapService.ReverseGeocode(latlng);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}

using GoongService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autocomplete_GoongMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        //private readonly GoongMapService _goongMapService;
        //public PlacesController(GoongMapService goongMapService)
        //{
        //    _goongMapService = goongMapService;
        //}
        //[HttpGet("autocomplete")]
        //public async Task<IActionResult> Autocomplete([FromQuery] string query, [FromQuery] double? latitude = null, [FromQuery] double? longitude = null)
        //{
        //    try
        //    {
        //        var results = await _goongMapService.GetAutocompleteResults(query, latitude, longitude);
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}
    }
}

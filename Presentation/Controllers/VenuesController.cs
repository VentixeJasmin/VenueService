using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class VenuesController(VenueService venueService) : ControllerBase
{
    private readonly VenueService _venueService = venueService;

    [Authorize]
    [HttpGet("form-data")]
    public IActionResult GetVenueFormData()
    {
        try
        {
            VenueDto dto = new();
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateVenue(VenueDto dto)
    {
        try
        {
            var result = await _venueService.CreateVenue(dto);
            return Created("", result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetVenues()
    {
        var venues = await _venueService.GetAllVenues();

        if (venues != null)
        {
            var orderedVenues = venues.OrderBy(v => v.Title).ToList();

            return Ok(orderedVenues);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVenueById(int id)
    {
        var venue = await _venueService.GetVenueById(id);

        if (venue != null)
        {
            return Ok(venue);
        }
        else
        {
            return NotFound();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SkyTrace.Api.Domain;

namespace SkyTrace.Api.Controllers;

[ApiController]
[Route("api/satellites")]
public class SatellitesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var satellites = new[]
        {
            new Satellite
            {
                Id = Guid.NewGuid(),
                Name = "ISS",
                Latitude = -33.86,
                Longitude = 151.21,
                AltitudeKm = 420,
                Timestamp = DateTimeOffset.UtcNow
            }
        };

        return Ok(satellites);
        
    }
}

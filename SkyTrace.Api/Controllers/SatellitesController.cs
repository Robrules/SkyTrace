using Microsoft.AspNetCore.Mvc;
using SkyTrace.Api.Domain;
using SkyTrace.Api.Services;
using System.Linq;


namespace SkyTrace.Api.Controllers;

[ApiController]
[Route("api/satellites")]
public class SatellitesController : ControllerBase
{
    private readonly IIssTrackingService _issTrackingService;

    public SatellitesController(IIssTrackingService issTrackingService)
    {
        this._issTrackingService = issTrackingService;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var satellites = await _issTrackingService.GetActiveSatellitesAsync();

        return Ok(satellites);
    }
}

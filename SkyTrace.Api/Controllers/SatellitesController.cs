using Microsoft.AspNetCore.Mvc;
using SkyTrace.Api.Domain;
using SkyTrace.Api.Services;
using System.Linq;


namespace SkyTrace.Api.Controllers;

[ApiController]
[Route("api/satellites")]
public class SatellitesController : ControllerBase
{
    private readonly ICelesTrakService _celesTrakService;

    public SatellitesController(ICelesTrakService celesTrakService)
    {
        this._celesTrakService = celesTrakService;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var satellites = await _celesTrakService.GetActiveSatellitesAsync();

        return Ok(satellites);
    }
}

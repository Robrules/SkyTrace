using Microsoft.AspNetCore.Mvc;

namespace SkyTrace.Api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            service = "SkyTrace.Api",
            status = "healthy",
            timestamp = DateTimeOffset.UtcNow
        });
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HealthCheckFullApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HealthCheckController : ControllerBase
{

    private readonly ILogger<HealthCheckController> _logger;
    public static bool isHealthy = true;
    //public static bool isHealthy { get; set; }

    public HealthCheckController(ILogger<HealthCheckController> logger)
    {
        _logger = logger;
    }

    
    [HttpGet(Name = "ToggleHealth")]
    public bool ToggleHealth()
    {
        _logger.LogInformation(DateTime.Now.ToString() +  " Toggle invoked. Variable = " + isHealthy);
        isHealthy = !isHealthy;
        return isHealthy;
    }

    [HttpGet(Name = "IsHealthy")]
    public ActionResult IsHealthy()
    {
        _logger.LogInformation(DateTime.Now.ToString() + " Health Check Invoked isHealthy = " + isHealthy);
        if (isHealthy)
        {
            return Ok("Things are good");
        }

        _logger.LogError(DateTime.Now.ToString() + " FAILED: job is down");
        return StatusCode(StatusCodes.Status400BadRequest, "job is down");
    }

}

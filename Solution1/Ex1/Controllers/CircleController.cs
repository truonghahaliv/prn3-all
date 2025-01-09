using Ex1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex1.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class CircleController : ControllerBase
{
    [HttpPost("calculate")]
    public IActionResult CalculateCircle([FromBody] double radius)
    {
        if (radius <= 0)
        {
            return BadRequest(new { message = "Radius must be greater than 0" });
        }

        double area = Math.PI * Math.Pow(radius, 2);
        double circumference = 2 * Math.PI * radius;

        var response = new CircleResponse()
        {
            Area = area,
            Circumference = circumference
        };

        return Ok(response);
    }
}
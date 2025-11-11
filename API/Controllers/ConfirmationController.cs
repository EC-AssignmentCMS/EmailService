using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfirmationController(IConfirmationService service) : ControllerBase
{
    private readonly IConfirmationService _service = service;

    [HttpPost("send-confirmation-email")]
    public async Task<IActionResult> SendConfirmationEmail([FromBody] ConfirmationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("ModelState not valid");

        try
        {
            await _service.SendConfirmationEmailAsync(request);
            return Ok("Confirmation email sent successfully.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

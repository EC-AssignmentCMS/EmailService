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
    public async Task<IActionResult> SendConfirmationEmail(ConfirmationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("ModelState not valid");

        var result = await _service.SendConfirmationEmailAsync(request);
        return result.Succeeded
            ? Accepted(result)
            : BadRequest(result);
    }
}

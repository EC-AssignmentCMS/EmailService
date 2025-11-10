using API.Models;

namespace API.Interfaces;

public interface IConfirmationService
{
    Task<object?> SendConfirmationEmailAsync(ConfirmationRequest request);
}
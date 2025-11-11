using API.Models;

namespace API.Interfaces;

public interface IConfirmationService
{
    Task SendConfirmationEmailAsync(ConfirmationRequest request);
}
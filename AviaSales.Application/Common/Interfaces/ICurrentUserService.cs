namespace AviaSales.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Task<string?> GetCurrentUserId();

    Task<bool> IsAuthorized();
}
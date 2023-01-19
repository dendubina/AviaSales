namespace AviaSales.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? Id { get; }

    string? Email { get; }

    Task<bool> IsAuthorized();
}
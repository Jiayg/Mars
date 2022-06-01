namespace Mars.Application.Contracts.Services;

public interface IDemoAppService : IApplicationService
{
    Task Lock();
}
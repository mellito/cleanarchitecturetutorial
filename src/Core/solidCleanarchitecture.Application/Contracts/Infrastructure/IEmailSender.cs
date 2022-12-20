using solidCleanarchitecture.Application.Modules;

namespace solidCleanarchitecture.Application.Contracts.Infrastructure;

public interface IEmailSender
{
    public Task<bool> SendEmail(Email email);
}

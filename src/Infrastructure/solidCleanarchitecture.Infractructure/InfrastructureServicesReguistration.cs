using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using solidCleanarchitecture.Application.Contracts.Infrastructure;
using solidCleanarchitecture.Application.Modules;
using solidCleanarchitecture.Infractructure.Mail;

namespace solidCleanarchitecture.Infractructure;

public static class InfrastructureServicesReguistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
        service.AddTransient<IEmailSender, EmailSender>();
        return service;
    }
}

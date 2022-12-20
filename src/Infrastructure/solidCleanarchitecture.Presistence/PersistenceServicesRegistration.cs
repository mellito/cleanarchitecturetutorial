
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Presistence.Repositories;

namespace solidCleanarchitecture.Presistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<solidCleanarchitectureDbContext>(options =>
        options.UseSqlServer(
            configuration.GetConnectionString("solidCleanarchitectureConnectionString")
        ));

        services.AddScoped(typeof(IGenericRespository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<IleaveAllocationRepository, LeaveAllocationRepository>();


        return services;

    }
}

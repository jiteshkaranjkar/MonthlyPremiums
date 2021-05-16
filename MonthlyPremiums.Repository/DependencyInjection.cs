using MonthlyPremiums.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MonthlyPremiums.Repository
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      services.AddDbContext<ApplicationDBContext>(options => options.UseInMemoryDatabase("MonthlyPremiums"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

      services.AddScoped<IOccupationRepository, OccupationRepository>();

      return services;
    }
  }
}
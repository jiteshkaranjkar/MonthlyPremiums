using Microsoft.EntityFrameworkCore;
using MonthlyPremiums.Domain.Entities;

namespace MonthlyPremiums.Repository.Context
{
  public class ApplicationDBContext : DbContext
  {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
      DBContextSeeder seedOccupations = new();
      seedOccupations.Seed(this);
    }
    public DbSet<Occupation> Occupations { get; set; }
    public DbSet<Rating> Ratings { get; set; }

  }
}

using Microsoft.EntityFrameworkCore;
using MonthlyPremiums.Domain.Entities;

namespace MonthlyPremiums.Repository.Context
{
  public class OccupationDBContext : DbContext
  {
    public OccupationDBContext(DbContextOptions<OccupationDBContext> options) : base(options)
    {
      OccupationDBContextSeeder seedOccupations = new();
      seedOccupations.Seed(this);
    }
    public DbSet<Occupation> Occupations { get; set; }

  }
}

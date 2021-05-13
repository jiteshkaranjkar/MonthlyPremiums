using Microsoft.EntityFrameworkCore;
using MonthlyPremiums.Domain.Entities;

namespace MonthlyPremiums.Repository.Context
{
  public class RatingDBContext : DbContext
  {
    public RatingDBContext(DbContextOptions<RatingDBContext> options) : base(options)
    {
      RatingDBContextSeeder seedRatings = new();
      seedRatings.Seed(this);
    }
    public DbSet<Rating> Ratings { get; set; }

  }
}

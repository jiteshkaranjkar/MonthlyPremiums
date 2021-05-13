using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Domain.Enums;
using System.Collections.Generic;

namespace MonthlyPremiums.Repository.Context
{
  public class RatingDBContextSeeder
  {
    public void Seed(RatingDBContext dbContext)
    {
      List<Rating> ratings = new()
      {
        new Rating()
        {
          Id = 1,
          Name = RatingType.Professional.ToString(),
          Factor = (decimal)1.0
        },
        new Rating()
        {
          Id = 1,
          Name = RatingType.WhiteCollar.ToString(),
          Factor = (decimal)1.25
        },
        new Rating()
        {
          Id = 1,
          Name = RatingType.LightManual.ToString(),
          Factor = (decimal)1.50
        },
        new Rating()
        {
          Id = 1,
          Name = RatingType.HeavyManual.ToString(),
          Factor = (decimal)1.75
        }
      };
      dbContext.Ratings.AddRange(ratings);
    }
  }
}

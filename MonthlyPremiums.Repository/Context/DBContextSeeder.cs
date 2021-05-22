using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MonthlyPremiums.Repository.Context
{
  public class DBContextSeeder
  {
    private List<Rating> ratings;
    public void Seed(ApplicationDBContext appDBContext)
    {
      SeedRatings(appDBContext);
      SeedOccupations(appDBContext);
    }

    private void SeedOccupations(ApplicationDBContext appDBContext)
    {
      List<Occupation> occupations = new()
      {
        new Occupation()
        {
          Id = 1,
          Name = OccupationType.Cleaner.ToString(),
          Rating = ratings.Where(x => x.Name == RatingType.LightManual.ToString()).FirstOrDefault()
        },
        new Occupation()
        {
          Id = 2,
          Name = OccupationType.Doctor.ToString(),
          Rating = ratings.Where(x => x.Name == RatingType.Professional.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 3,
          Name = OccupationType.Author.ToString(),
          Rating = ratings.Where(x => x.Name == RatingType.WhiteCollar.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 4,
          Name = OccupationType.Farmer.ToString(),
          Rating = ratings.Where(x => x.Name == RatingType.HeavyManual.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 5,
          Name = OccupationType.Mechanic.ToString(),
          Rating = ratings.Where(x => x.Name == RatingType.HeavyManual.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 6,
          Name = OccupationType.Florist.ToString(),
          Rating = ratings.Where(x => x.Name == RatingType.LightManual.ToString()).FirstOrDefault()
        }
      };
      appDBContext.Occupations.AddRange(occupations);
    }

    private void SeedRatings(ApplicationDBContext appDBContext)
    {
      ratings = new()
      {
        new Rating()
        {
          Id = 1,
          Name = RatingType.Professional.ToString(),
          Factor = (decimal)1.0
        },
        new Rating()
        {
          Id = 2,
          Name = RatingType.WhiteCollar.ToString(),
          Factor = (decimal)1.25
        },
        new Rating()
        {
          Id = 3,
          Name = RatingType.LightManual.ToString(),
          Factor = (decimal)1.50
        },
        new Rating()
        {
          Id = 4,
          Name = RatingType.HeavyManual.ToString(),
          Factor = (decimal)1.75
        }
      };
      appDBContext.Ratings.AddRange(ratings);
    }
  }
}

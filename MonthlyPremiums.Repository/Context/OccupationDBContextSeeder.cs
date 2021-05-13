using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MonthlyPremiums.Repository.Context
{
  public class OccupationDBContextSeeder
  {
    public void Seed(OccupationDBContext occupationDBContext)
    {
      List<Occupation> occupations = new()
      {
        new Occupation()
        {
          Id = 1,
          Name = OccupationType.Cleaner.ToString(),
          //Rating = ratingDBContext.Ratings.Where(x => x.Name == RatingType.LightManual.ToString()).FirstOrDefault()
        },
        new Occupation()
        {
          Id = 2,
          Name = OccupationType.Doctor.ToString(),
          //Rating = ratingDBContext.Ratings.Where(x => x.Name == RatingType.Professional.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 3,
          Name = OccupationType.Author.ToString(),
          //Rating = ratingDBContext.Ratings.Where(x => x.Name == RatingType.WhiteCollar.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 4,
          Name = OccupationType.Farmer.ToString(),
          //Rating = ratingDBContext.Ratings.Where(x => x.Name == RatingType.HeavyManual.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 5,
          Name = OccupationType.Mechanic.ToString(),
          //Rating = ratingDBContext.Ratings.Where(x => x.Name == RatingType.HeavyManual.ToString()).FirstOrDefault()
        },

        new Occupation()
        {
          Id = 6,
          Name = OccupationType.Florist.ToString(),
          //Rating = ratingDBContext.Ratings.Where(x => x.Name == RatingType.LightManual.ToString()).FirstOrDefault()
        }
      };

      occupationDBContext.Occupations.AddRange(occupations);
    }
  }
}

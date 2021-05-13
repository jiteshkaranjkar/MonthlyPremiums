using MonthlyPremiums.Domain.Entities;
using System.Collections.Generic;

namespace MonthlyPremiums.Service.Contracts
{
    public interface IRatingService
    {
        List<Rating> GetAllRatings();
        Rating GetRatingByID(int id);
    }
}

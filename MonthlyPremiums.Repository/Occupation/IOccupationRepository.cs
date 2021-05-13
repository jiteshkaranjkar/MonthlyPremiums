using System.Collections.Generic;
using MonthlyPremiums.Domain.Entities;


namespace MonthlyPremiums.Repository
{
  public interface IOccupationRepository
  {
    List<Occupation> GetAllOccupations();

    Occupation GetOccupationById(int id);
  }
}

using MonthlyPremiums.Domain.Entities;
using System.Collections.Generic;

namespace MonthlyPremiums.Service.Contracts
{
  public interface IOccupationService
  {
    List<Occupation> GetAllOccupations();
    Occupation GetOccupationById(int id);
  }
}

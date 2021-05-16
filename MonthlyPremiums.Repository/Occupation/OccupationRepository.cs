using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace MonthlyPremiums.Repository
{
  public class OccupationRepository : IOccupationRepository
  {
    private ApplicationDBContext _context;

    public OccupationRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    public List<Occupation> GetAllOccupations() => _context.Occupations.Local.ToList();

    public Occupation GetOccupationById(int id) => _context.Occupations.Where(occup => occup.Id == id).FirstOrDefault();
  }
}
using MonthlyPremiums.Domain.Entities.Common;

namespace MonthlyPremiums.Domain.Entities
{
  public class Occupation : BaseEntity
  {
    public string Name { get; set; }
    public Rating Rating { get; set; }
  }
}

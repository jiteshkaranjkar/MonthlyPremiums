using MonthlyPremiums.Domain.Entities.Common;

namespace MonthlyPremiums.Domain.Entities
{
  public class Rating : BaseEntity
  {
    public string Name { get; set; }
    public decimal Factor { get; set; }
  }
}

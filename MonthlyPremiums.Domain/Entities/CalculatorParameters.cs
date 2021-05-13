namespace MonthlyPremiums.Domain.Entities
{
  public class CalculatorParameters
  {
    /// <summary>
    /// Your name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Your age
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Your date of birth
    /// </summary>
    public string Dob { get; set; }

    /// <summary>
    /// Occupation ID
    /// </summary>
    public int OccupationId { get; set; }

    /// <summary>
    /// Sum assured required
    /// </summary>
    public decimal DeathSumInsured { get; set; }
  }
}
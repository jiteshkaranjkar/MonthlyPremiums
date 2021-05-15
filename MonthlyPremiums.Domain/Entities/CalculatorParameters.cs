namespace MonthlyPremiums.Domain.Entities
{
  public class CalculatorParameters
  {
    /// <summary>
    /// Customer name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Customer age
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Customer date of birth
    /// </summary>
    public string Dob { get; set; }

    /// <summary>
    /// Customer Occupation ID
    /// </summary>
    public int OccupationId { get; set; }

    /// <summary>
    /// Sum assured required
    /// </summary>
    public decimal DeathSumInsured { get; set; }
  }
}
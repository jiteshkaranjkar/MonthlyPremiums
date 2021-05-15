using MonthlyPremiums.Domain;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Service.Exceptions;
using System;

namespace MonthlyPremiums.Service.Concretes
{
  public class CalculatorService : ICalculatorService
  {
    private readonly IOccupationService _occupationService;
    public CalculatorService(IOccupationService occupationService)
    {
      _occupationService = occupationService;
    }
    public decimal? CalculateMonthlyPremium(CalculatorParameters calculatorParameters)
    {
      decimal? premium = null;
      calculatorParameters.OccupationId = 1;

      // Get occupation details
      Occupation occupation = _occupationService.GetOccupationById(calculatorParameters.OccupationId);

      premium = Math.Round(calculatorParameters.DeathSumInsured * occupation.Rating.Factor * calculatorParameters.Age / 1000, 2);

      return premium;
    }

  }
}

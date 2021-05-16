using MonthlyPremiums.Domain;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Service.Exceptions;
using System;

namespace MonthlyPremiums.Service.Concretes
{
  /// <summary>
  /// Service class that calculateds the monthly premium based on the Given formula
  /// </summary>
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

      // Get occupation details
      #region Business validations
      if (calculatorParameters == null)
      {
        throw new BusinessException(CommonConstants.INVALID_CALCULATOR_PARAMETER_INPUT);
      }

      if (calculatorParameters.DeathSumInsured <= 0)
      {
        throw new BusinessException(CommonConstants.INVALID_DEATH_SUM_INSURED_INPUT);
      }

      if (calculatorParameters.Age <= 0)
      {
        throw new BusinessException(CommonConstants.INVALID_AGE_INPUT);
      }

      if (calculatorParameters.Age > 120)
      {
        throw new BusinessException(CommonConstants.OUT_OF_RANGE_AGE_INPUT);
      }
      #endregion

      Occupation occupation = _occupationService.GetOccupationById(calculatorParameters.OccupationId);

      if (occupation == null)
      {
        throw new BusinessException(CommonConstants.OCCUPATION_NOT_FOUND);
      }
      
      premium = Math.Round(calculatorParameters.DeathSumInsured * occupation.Rating.Factor * calculatorParameters.Age / 1000 * 12, 2);

      return premium;
    }

  }
}

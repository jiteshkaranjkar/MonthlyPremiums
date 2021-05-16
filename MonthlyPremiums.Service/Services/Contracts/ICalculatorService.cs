using MonthlyPremiums.Domain.Entities;

namespace MonthlyPremiums.Service.Contracts
{
  public interface ICalculatorService
  {
    decimal? CalculateMonthlyPremium(CalculatorParameters calculatorParameters);
  }
}

using MonthlyPremiums.Domain;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Concretes;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Service.Exceptions;
using Moq;
using System;
using Xunit;

namespace MonthlyPremiumsTest.Services
{
  public class CalculatorServiceTest
  {
    private ICalculatorService _sutCalculatorService;
    private Mock<IOccupationService> _mockOccupationService;

    public CalculatorServiceTest()
    {
      _mockOccupationService = new Mock<IOccupationService>();
      _sutCalculatorService = new CalculatorService(_mockOccupationService.Object);
    }

    [Fact]
    public void Check_CalculateMonthlyPremium_ThrowNullPointerException_WhenCalculatorParameters_IsNull()
    {
      CalculatorParameters calculatorParameters = null;
      Exception ex = Assert.Throws<BusinessException>(() => _sutCalculatorService.CalculateMonthlyPremium(calculatorParameters));

      Assert.Equal(CommonConstants.INVALID_CALCULATOR_PARAMETER_INPUT, ex.Message);
    }

    [Fact]
    public void Check_CalculateMonthlyPremium_ThrowBusinessException_WhenOccupationId_Is0()
    {
      CalculatorParameters calculatorParameters = new CalculatorParameters
      { DeathSumInsured = 5000, OccupationId = 0, Age = 78 };
      Exception ex = Assert.Throws<BusinessException>(() => _sutCalculatorService.CalculateMonthlyPremium(calculatorParameters));

      Assert.Equal(CommonConstants.OCCUPATION_NOT_FOUND, ex.Message);
    }

    [Fact]
    public void Check_CalculateMonthlyPremium_ThrowBusinessException_WhenAge_Is0()
    {
      CalculatorParameters calculatorParameters = new CalculatorParameters
      { DeathSumInsured = 5000, OccupationId = 1, Age = 0 };
      Exception ex = Assert.Throws<BusinessException>(() => _sutCalculatorService.CalculateMonthlyPremium(calculatorParameters));

      Assert.Equal(CommonConstants.INVALID_AGE_INPUT, ex.Message);
    }

    [Fact]
    public void Check_CalculateMonthlyPremium_ThrowBusinessException_WhenAge_Is120()
    {
      CalculatorParameters calculatorParameters = new CalculatorParameters
      { DeathSumInsured = 5000, OccupationId = 1, Age = 121 };
      Exception ex = Assert.Throws<BusinessException>(() => _sutCalculatorService.CalculateMonthlyPremium(calculatorParameters));

      Assert.Equal(CommonConstants.OUT_OF_RANGE_AGE_INPUT, ex.Message);
    }

    [Fact]
    public void Check_CalculateMonthlyPremium_ThrowNullPointerException_WhenDeathSumInsured_Is0()
    {
      CalculatorParameters calculatorParameters = new CalculatorParameters
      { DeathSumInsured = 0, OccupationId = 1, Age = 55 };
      Exception ex = Assert.Throws<BusinessException>(() => _sutCalculatorService.CalculateMonthlyPremium(calculatorParameters));
      Assert.Equal(CommonConstants.INVALID_DEATH_SUM_INSURED_INPUT, ex.Message);
    }

  }
}

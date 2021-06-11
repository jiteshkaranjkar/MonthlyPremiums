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

    [Theory]
    [InlineData(3, 7, 1.75, 129387, 19019.89)]
    [InlineData(5, 119, 1.25, 764, 1363.74)]
    [InlineData(1, 59, 1.00, 50000, 35400)]
    [InlineData(6, 97, 1.50, 10, 17.46)]
    public void Check_CalculateMonthlyPremium_WithTestData(int occupationId, int age, decimal factor, int deathSumInsured, decimal premiumAmount)
    {
      _mockOccupationService.Setup(ocpt => ocpt.GetOccupationById(occupationId)).Returns(
        new Occupation
        {
          Id = occupationId,
          Name = It.IsAny<String>(),
          Rating = new()
          {
            Id = 1,
            Name = It.IsAny<String>(),
            Factor = factor
          }
        });
      CalculatorParameters calParam = new()
      {
        Age = age,
        OccupationId = occupationId,
        DeathSumInsured = deathSumInsured
      };
      decimal? premium = _sutCalculatorService.CalculateMonthlyPremium(calParam);

      Assert.Equal(premiumAmount, premium);
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

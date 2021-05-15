using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Concretes;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Service.Exceptions;
using Moq;
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
    public void Check_CalculateMonthlyPremium_ThrowNullPointerException_WhenNullcalculatorParameters()
    {
      CalculatorParameters calculatorParameters = null;
      Assert.Throws<NotFoundException>(() => _sutCalculatorService.CalculateMonthlyPremium(calculatorParameters));
    }
  }
}

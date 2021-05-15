using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Presentation.Controllers;
using MonthlyPremiums.Service.Contracts;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MonthlyPremiumsTest.Controller
{
  public class PremiumControllerTest
  {
    private Mock<ICalculatorService> _mockCalculatorService;
    private PremiumController _sutController;
    private ILogger<PremiumController> _logger;

    public PremiumControllerTest()
    {
      _mockCalculatorService = new Mock<ICalculatorService>();
      _sutController = new PremiumController(_logger, _mockCalculatorService.Object);
    }

    [Fact]
    public void Check_GetShoppingTrolley_ReturnsNull()
    {
      CalculatorParameters calculatorParameters = null;
      decimal? sumInssured = _sutController.CalculateMonthlyPremium(calculatorParameters);
      Assert.Null(sumInssured);
    }
  }
}

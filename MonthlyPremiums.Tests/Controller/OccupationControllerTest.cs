using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Presentation.Controllers;
using MonthlyPremiums.Service.Contracts;
using Moq;
using Xunit;

namespace MonthlyPremiumsTest.Controller
{
  public class OccupationControllerTest
  {
    private Mock<IOccupationService> _mockOccupationService;
    private OccupationController _sutController;
    private ILogger<OccupationController> _logger;

    public OccupationControllerTest()
    {
      _mockOccupationService = new Mock<IOccupationService>();
      _sutController = new OccupationController(_logger, _mockOccupationService.Object);
    }


    [Fact]
    public void Check_GetOccupations_ReturnsNull()
    {
      MonthlyPremium monthlyPremium = _sutController.GetAllOccupations();
      Assert.Null(monthlyPremium.occupationList);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(4)]
    public void Check_GetOccupationById(int OccupationId)
    {
      Occupation Occupation = _sutController.GetOccupationById(OccupationId);
      Assert.Null(Occupation);
    }


    [Fact]
    public void Check_GetOccupationById_WithZeroIndex()
    {
      Occupation Occupation = _sutController.GetOccupationById(0);
      Assert.Null(Occupation);
    }
  }
}

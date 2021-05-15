using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Repository;
using MonthlyPremiums.Service.Concretes;
using MonthlyPremiums.Service.Contracts;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MonthlyPremiumsTest.Services
{
  public class OccupationServiceTest
  {
    private IOccupationService _sutOccupationService;
    private Mock<IOccupationRepository> _mockOccupationRepository;

    public OccupationServiceTest()
    {
      _mockOccupationRepository = new Mock<IOccupationRepository>();
      _sutOccupationService = new OccupationService(_mockOccupationRepository.Object);
    }

    [Fact]
    public void Check_GetAllOccupations_ReturnsNull()
    {
      List<Occupation> occupationList = _sutOccupationService.GetAllOccupations();
      Assert.Null(occupationList);
    }

  }
}

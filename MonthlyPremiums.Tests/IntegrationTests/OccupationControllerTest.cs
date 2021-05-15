using Microsoft.Extensions.Logging;
using MonthlyPremiums.Presentation.Controllers;
using MonthlyPremiums.Repository;
using MonthlyPremiums.Repository.Context;
using MonthlyPremiums.Service.Concretes;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Web;
using System;
using Xunit;

namespace MonthlyPremiumsTest.IntegrationTests
{
  public class OccupationControllerTest : IClassFixture<TestFixture<Startup>>, IDisposable
  {
    private IOccupationService _occupationService;
    private IOccupationRepository _occupationRepository;
    private OccupationController _OccupationController;
    private ILogger<OccupationController> _logger;
    private OccupationDBContext _occupationDBContext;
    private TestFixture<Startup> _testFixture;

    public OccupationControllerTest(TestFixture<Startup> fixture)
    {
      _testFixture = fixture;
      _occupationDBContext = _testFixture.CreateDbContext();
      _occupationRepository = new OccupationRepository(_occupationDBContext);
      _occupationService = new OccupationService(_occupationRepository);
      _OccupationController = new(_logger, _occupationService);
    }

    [Fact]
    public void Check_GetAllOccupations()
    {
      MonthlyPremium monthlyPremium = _OccupationController.GetAllOccupations();
      Assert.IsType<MonthlyPremium>(monthlyPremium);

      Assert.Equal(6, monthlyPremium.occupationList.Count);

    }

    public void Dispose()
    {
      _occupationDBContext.Dispose();
    }

  }
}

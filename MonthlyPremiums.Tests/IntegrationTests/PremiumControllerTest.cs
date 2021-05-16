using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Presentation.Controllers;
using MonthlyPremiums.Repository;
using MonthlyPremiums.Repository.Context;
using MonthlyPremiums.Service.Concretes;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Web;
using System;
using System.Collections.Generic;
using Xunit;

namespace MonthlyPremiumsTest.IntegrationTests
{
  public class PremiumControllerTest : IClassFixture<TestFixture<Startup>>, IDisposable
  {
    private IOccupationService _occupationService;
    private ICalculatorService _calculatorService;
    private IOccupationRepository _occupationRepository;
    private PremiumController _premiumController;
    private readonly ILogger<PremiumController> _logger;
    private ApplicationDBContext _appDBContext;
    private TestFixture<Startup> _testFixture;
    private CalculatorParameters _calculatorParameters;

    public PremiumControllerTest(TestFixture<Startup> fixture)
    {
      _testFixture = fixture;
      _appDBContext = _testFixture.CreateDbContext();
      _occupationRepository = new OccupationRepository(_appDBContext);
      _occupationService = new OccupationService(_occupationRepository);
      _calculatorService = new CalculatorService(_occupationService);
      _premiumController = new(_logger, _calculatorService);
    }

    [Fact]
    public void Check_GetAllOccupations()
    {
      _calculatorParameters = new()
      { 
        Age = 10,
        DeathSumInsured = 50000,
        OccupationId = 4,
      };
      decimal? premium = _premiumController.CalculateMonthlyPremium(_calculatorParameters);
      Assert.IsType<decimal>(premium);

      Occupation ocpn = _occupationService.GetOccupationById(_calculatorParameters.OccupationId);

      Assert.Equal(Math.Round(_calculatorParameters.DeathSumInsured * ocpn.Rating.Factor * _calculatorParameters.Age / 1000 * 12, 2), premium);

    }


    [Theory]
    [InlineData(34, 50000, 1)]
    [InlineData(2, 100000, 4)]
    [InlineData(99, 20000, 3)]
    [InlineData(120, 150000, 2)]
    [InlineData(10, 25000, 6)]
    [InlineData(55, 125000, 5)]
    public void CalculateMonthlyPremium_Validate_Result(int age, int deathSumInsured, int occupationId)
    {
      _calculatorParameters = new()
      {
        Age = age,
        DeathSumInsured = deathSumInsured,
        OccupationId = occupationId,
      };

      decimal? premium = _premiumController.CalculateMonthlyPremium(_calculatorParameters);
      Assert.IsType<decimal>(premium);

      Occupation ocpn = _occupationService.GetOccupationById(_calculatorParameters.OccupationId);

      Assert.Equal(Math.Round(_calculatorParameters.DeathSumInsured * ocpn.Rating.Factor * _calculatorParameters.Age / 1000 * 12, 2), premium);
    }

    public void Dispose()
    {
      _appDBContext.Dispose();
    }

  }
}

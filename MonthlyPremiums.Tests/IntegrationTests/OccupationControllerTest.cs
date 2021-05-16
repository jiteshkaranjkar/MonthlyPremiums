using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Domain.Enums;
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
  public class OccupationControllerTest : IClassFixture<TestFixture<Startup>>, IDisposable
  {
    private IOccupationService _occupationService;
    private IOccupationRepository _occupationRepository;
    private OccupationController _occupationController;
    private readonly ILogger<OccupationController> _logger;
    private ApplicationDBContext _appDBContext;
    private TestFixture<Startup> _testFixture;

    public OccupationControllerTest(TestFixture<Startup> fixture)
    {
      _testFixture = fixture;
      _appDBContext = _testFixture.CreateDbContext();
      _occupationRepository = new OccupationRepository(_appDBContext);
      _occupationService = new OccupationService(_occupationRepository);
      _occupationController = new(_logger, _occupationService);
    }

    [Fact]
    public void Check_GetAllOccupations()
    {
      List<Occupation> lstOccupation = _occupationController.GetAllOccupations();
      Assert.IsType<List<Occupation>>(lstOccupation);

      Assert.Equal(6, lstOccupation.Count);
    }


    [Theory]
    [InlineData(3, CommonConstants.AUTHOR, CommonConstants.WHITE_COLLAR, 1.25)]
    [InlineData(1, CommonConstants.CLEANER, CommonConstants.LIGHT_MANUAL, 1.50)]
    [InlineData(5, CommonConstants.MECHANIC, CommonConstants.HEAVY_MANUAL, 1.75)]
    [InlineData(2, CommonConstants.DOCTOR, CommonConstants.PROFESSIONAL, 1)]
    [InlineData(6, CommonConstants.Florist, CommonConstants.LIGHT_MANUAL, 1.50)]
    [InlineData(4, CommonConstants.FARMER, CommonConstants.HEAVY_MANUAL, 1.75)]
    public void Check_GetOccupationById(int occupationId, string occupationType, string ratingType, decimal ratingFactor)
    {
      Occupation ocpn = _occupationController.GetOccupationById(occupationId);
      Assert.IsType<Occupation>(ocpn);
      Assert.Equal(ocpn.Id, occupationId);
      Assert.Equal(ocpn.Name, occupationType);
      Assert.Equal(ocpn.Rating.Name, ratingType);
      Assert.Equal(ocpn.Rating.Factor, ratingFactor);
    }

    public void Dispose()
    {
      _appDBContext.Dispose();
    }

  }
}

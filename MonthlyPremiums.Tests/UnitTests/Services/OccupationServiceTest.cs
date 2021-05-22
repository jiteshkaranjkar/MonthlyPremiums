using MonthlyPremiums.Domain;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Repository;
using MonthlyPremiums.Service.Concretes;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Service.Exceptions;
using Moq;
using System;
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

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    public void Check_GetOccupationById_WithTestData(int occupationId)
    {
      _mockOccupationRepository.Setup(ocpt => ocpt.GetOccupationById(occupationId)).Returns(
        new Occupation
        {
          Id = occupationId,
          Name = It.IsAny<String>(),
          Rating = new() { 
            Id = 1,
            Name = It.IsAny<String>(),
            Factor = 1.1m
          }
        });

      Assert.Equal(occupationId, _sutOccupationService.GetOccupationById(occupationId).Id);
    }

    [Fact]
    public void Check_GetAllOccupations_ReturnsNull()
    {
      Exception ex = Assert.Throws<NotFoundException>(() => _sutOccupationService.GetAllOccupations());

      Assert.Equal(CommonConstants.NO_OCCUPATIONS_FOUND_EXCEPTION, ex.Message);
    }

    [Fact]
    public void Check_GetOccupationById_ReturnNull_whenOccupationId_Is0()
    {
      Exception ex = Assert.Throws<NotFoundException>(() => _sutOccupationService.GetOccupationById(0));

      Assert.Equal(CommonConstants.NO_OCCUPATIONS_FOUND_EXCEPTION, ex.Message);
    }
  }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Contracts;
using System.Collections.Generic;

namespace MonthlyPremiums.Presentation.Controllers
{
  /// <summary>
  /// Calls Occupation service and returns all or one Occupation
  /// </summary>
  [ApiController]
  [Route("api/[controller]")]
  public class OccupationController : ControllerBase
  {
    private ILogger<OccupationController> _logger;
    private IOccupationService _occupationService;

    /// <summary>
    /// Constructor assigning dependincies
    /// </summary>
    /// <param name="logger">Looger to be used for Logging</param>
    /// <param name="occupationService">occupation Service</param>
    public OccupationController(ILogger<OccupationController> logger,  IOccupationService occupationService)
    {
      _logger = logger;
      _occupationService = occupationService;
    }

    /// <summary>
    /// Gets all the Occupations along with the ratings
    /// </summary>
    /// <returns>list of all occupations</returns>
    // GET: api/Occupation
    [HttpGet]
    public List<Occupation> GetAllOccupations()
    {
      return _occupationService.GetAllOccupations();
    }

    /// <summary>
    /// Gets the Occupations along with the ratings based on given Occupation Id
    /// </summary>
    /// <param name="occupationId">Input occupation Id to get that occupation</param>
    /// <returns>occupation based on occupation Id</returns>
    // GET: api/Occupation/1
    [HttpGet("{id}")]
    public Occupation GetOccupationById(int occupationId)
    {
      return _occupationService.GetOccupationById(occupationId);
    }
  }
}

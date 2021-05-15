using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Contracts;
using System.Collections.Generic;

namespace MonthlyPremiums.Presentation.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OccupationController : ControllerBase
  {
    private ILogger<OccupationController> _logger;
    private IOccupationService _occupationService;

    public OccupationController(ILogger<OccupationController> logger,  IOccupationService occupationService)
    {
      _logger = logger;
      _occupationService = occupationService;
    }

    // GET: api/Occupations
    [HttpGet]
    public MonthlyPremium GetAllOccupations()
    {
      MonthlyPremium mp = new MonthlyPremium();
      mp.calculatorParameters = new CalculatorParameters();
      mp.occupationList = _occupationService.GetAllOccupations();
      return mp;
    }
    
    // GET: api/Occupation/1
    [HttpGet("{id}")]
    public Occupation GetOccupationById(int id)
    {
      return _occupationService.GetOccupationById(id);
    }
  }

  public class MonthlyPremium
  {
    public CalculatorParameters calculatorParameters { get; set; }
    public List<Occupation> occupationList { get; set; }
  }
}

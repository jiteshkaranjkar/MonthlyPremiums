using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Contracts;

namespace MonthlyPremiums.Presentation.Controllers
{
  /// <summary>
  /// Calls Calculator service and returns the Monthly Premium
  /// </summary>
  [ApiController]
  [Route("api/[controller]")]
  public class PremiumController : ControllerBase
  {
    private ILogger<PremiumController> _logger;
    private ICalculatorService _calculatorService;

    /// <summary>
    /// Constructor assigning dependincies
    /// </summary>
    /// <param name="logger">Looger to be used for Logging</param>
    /// <param name="calculatorService">Calculator Service</param>
    public PremiumController(ILogger<PremiumController> logger,  ICalculatorService calculatorService)
    {
      _logger = logger;
      _calculatorService = calculatorService;
    }

    /// <summary>
    /// Calculate monthly premium based on User inpur from UI
    /// </summary>
    /// <param name="calculatorParameters">UI input in CalculatorParameter object calculating monthly premium</param>
    /// <returns>Monthly premium</returns>
    [HttpPost]
    public decimal? CalculateMonthlyPremium(CalculatorParameters calculatorParameters)
    {
      return _calculatorService.CalculateMonthlyPremium(calculatorParameters);
    }
  }
}

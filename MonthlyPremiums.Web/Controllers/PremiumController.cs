using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Service.Contracts;

namespace MonthlyPremiums.Presentation.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PremiumController : ControllerBase
  {
    private ILogger<PremiumController> _logger;
    private ICalculatorService _calculatorService;

    public PremiumController(ILogger<PremiumController> logger,  ICalculatorService calculatorService)
    {
      _logger = logger;
      _calculatorService = calculatorService;
    }

    // Post: api/CalculateMonthlyPremium
    [HttpPost]
    public decimal? CalculateMonthlyPremium(CalculatorParameters calculatorParameters)
    {
      return _calculatorService.CalculateMonthlyPremium(calculatorParameters);
    }
  }
}

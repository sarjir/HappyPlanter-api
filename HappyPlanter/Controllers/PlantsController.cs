using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HappyPlanter.Controllers {
  [ApiController]
  [Route ("[controller]")]
  public class PlantsController : ControllerBase {
    private readonly ILogger<PlantsController> _logger;

    public PlantsController (ILogger<PlantsController> logger) {
      _logger = logger;
    }

    [HttpGet]
    public string Get () {
      return "Hello from the /plants url!";
    }
  }
}
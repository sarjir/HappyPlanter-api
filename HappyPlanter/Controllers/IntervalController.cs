using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HappyPlanter.Controllers {
  [ApiController]
  [Route ("[controller]")]
  public class IntervalController : ControllerBase {
    [HttpGet]
    public ActionResult Get () {
      var test = Environment.GetEnvironmentVariable ("DB_CONNECTION_STRING");
      var connection = new NpgsqlConnection (test);

      connection.Open ();

      var selectAllFromInterval = "SELECT * FROM Intervals";
      var intervals = connection.Query<Interval> (selectAllFromInterval).ToList ();

      return Ok (intervals);
    }
  }
}
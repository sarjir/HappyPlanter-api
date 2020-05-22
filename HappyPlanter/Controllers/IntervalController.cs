using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HappyPlanter.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class IntervalController : ControllerBase
  {
    [HttpGet("{planter_id}")]
    public ActionResult GetPlantsForUser(int planter_id)
    {
      var test = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
      var connection = new NpgsqlConnection(test);

      connection.Open();

      Console.WriteLine(planter_id);

      var selectAllFromInterval = $"SELECT * FROM Intervals WHERE planter_id={planter_id}";
      var intervals = connection.Query<Interval>(selectAllFromInterval).ToList();

      return Ok(intervals);
    }
  }
}
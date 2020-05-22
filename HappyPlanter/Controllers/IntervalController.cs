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

      var selectAllFromInterval = $"SELECT * FROM Intervals WHERE planter_id={planter_id}";
      var intervals = connection.Query<Interval>(selectAllFromInterval).ToList();

      var intervalsWithDaysUntilWater = calculateDaysUntilWater(intervals);

      return Ok(intervalsWithDaysUntilWater);
    }

    private List<Interval> calculateDaysUntilWater(List<Interval> intervals)
    {
      foreach (Interval singleInterval in intervals)
      {
        var latestTime = singleInterval.Latest_Time;
        var interval = singleInterval.Interval_Time;
        var theDayToWater = latestTime + interval;
        var daysUntilWater = theDayToWater - DateTime.Now;

        singleInterval.Days_Until_Water = daysUntilWater;
      }

      return intervals;
    }
  }
}
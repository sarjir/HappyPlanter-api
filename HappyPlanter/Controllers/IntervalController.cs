using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HappyPlanter.Controllers
{
  class Event
  {
    public int Id { get; set; }
    public DateTime Time_Stamp { get; set; }
    public string Event_Type { get; set; }
    public int Plant_Id { get; set; }
  }
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

    [HttpPost("plant/{plant_id}/water")]
    public ActionResult addWaterEvent(int plant_id)
    {
      var test = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
      var connection = new NpgsqlConnection(test);

      connection.Open();

      var insertEvent = $"INSERT INTO Event VALUES (DEFAULT, Now(), 'water', {plant_id})";
      var hello = connection.Query<Event>(insertEvent).ToList();
      var latestEvent = $"SELECT * FROM Event WHERE plant_id={plant_id} ORDER BY Time_Stamp DESC LIMIT 1";
      var goodbye = connection.Query<Event>(latestEvent).ToList();

      Console.WriteLine("goodbye");
      Console.WriteLine(goodbye);
      return Ok(goodbye[0]);
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
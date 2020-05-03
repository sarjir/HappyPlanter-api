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
  public class PlantsController : ControllerBase {
    [HttpGet]
    public ActionResult Get () {
      var test = Environment.GetEnvironmentVariable ("DB_CONNECTION_STRING");
      var connection = new NpgsqlConnection (test);

      connection.Open ();

      var selectAllFromPlants = "SELECT * FROM Plant";
      var plants = connection.Query<Plant> (selectAllFromPlants).ToList ();

      plants.ForEach (plant => { Console.WriteLine (plant.Name); });

      return Ok (plants);
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
// using Plant;

namespace HappyPlanter {

  public class Program {
    public static void Main (string[] args) {
      var test = Environment.GetEnvironmentVariable ("DB_CONNECTION_STRING");
      var connection = new NpgsqlConnection (test);

      connection.Open ();

      var selectAllFromPlants = "SELECT * FROM Plants";
      var plants = connection.Query<Plant> (selectAllFromPlants).ToList ();

      plants.ForEach (plant => { Console.WriteLine (plant.Name); });

      CreateHostBuilder (args).Build ().Run ();
    }

    public static IHostBuilder CreateHostBuilder (string[] args) =>
      Host.CreateDefaultBuilder (args)
      .ConfigureWebHostDefaults (webBuilder => {
        webBuilder.UseStartup<Startup> ();
      });
  }
}
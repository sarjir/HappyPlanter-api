using System;
using System.Collections.Generic;
using Dapper;

namespace HappyPlanter
{
  class Interval
  {
    public int Planter_Id { get; set; }
    public int Plant_Id { get; set; }
    public TimeSpan Interval_Time { get; set; }
    public DateTime Latest_Time { get; set; }
    public TimeSpan Days_Until_Water { get; set; }
  }
}
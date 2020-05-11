using System;
using System.Collections.Generic;
using Dapper;

namespace HappyPlanter {
  class Interval {
    public int Plant_Id { get; set; }
    public TimeSpan Interval_Time { get; set; }
    public DateTime Latest_Time { get; set; }
  }
}
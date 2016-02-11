using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaperChrisFitbitWeb.Model
{
    public class GameFitbitModel
    {
        public List<FitbitRate> FitbitResults { get; set; } 
    }

    public class FitbitRate
    {
        public int HeartRate { get; set; }
        public double Time { get; set; }

        public int StartTime { get; set; }

        public string FileName { get; set; }
    }
}

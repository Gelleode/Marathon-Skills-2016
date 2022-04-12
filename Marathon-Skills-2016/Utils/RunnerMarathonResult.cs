using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon_Skills_2016.Utils
{
    class RunnerMarathonResult
    {
        public short Year { get; set; }
        public string Country { get; set; }
        public string EventType { get; set; }
        public int RaceTime { get; set; }
        public TimeSpan Time { get { return TimeSpan.FromSeconds(RaceTime); } }
        public int TotalPlace { get; set; }
        public int CatPlace { get; set; }
    }
}

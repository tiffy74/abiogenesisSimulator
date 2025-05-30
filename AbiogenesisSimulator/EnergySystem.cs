using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbiogenesisSimulator
{
    public class EnergyEvent
    {
        public int StartTime { get; set; }
        public int Duration { get; set; }
        public double EnergyChange { get; set; }
    }

    public static class EventSystem
    {
        public static double ApplyEvents(List<EnergyEvent> events, int t, double currentZ)
        {
            foreach (var evt in events)
            {
                if (t >= evt.StartTime && t < evt.StartTime + evt.Duration)
                {
                    return currentZ + evt.EnergyChange;
                }
            }
            return currentZ;
        }

        public static List<EnergyEvent> GetStandardEvents()
        {
            return new List<EnergyEvent>
            {
                new EnergyEvent { StartTime = 150, Duration = 20, EnergyChange = -5 }, // Simulate asteroid impact
                new EnergyEvent { StartTime = 300, Duration = 50, EnergyChange = 3 }   // Simulate volcanic outgassing
            };
        }
    }
}

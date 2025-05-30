using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbiogenesisSimulator
{
    public static class SunModel
    {
        public static double ModifyEnergyBasedOnSunAge(int t, double currentZ)
        {
            if (t < 100) // Formation chaos
                return currentZ + (new System.Random().NextDouble() - 0.5) * 10;
            else if (t < 300) // Early instability (T Tauri phase)
                return currentZ + Math.Sin(t * 0.3) * 6;
            else // Stable main sequence
                return currentZ;
        }
    }
}

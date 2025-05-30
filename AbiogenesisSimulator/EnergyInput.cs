using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbiogenesisSimulator
{
    public static class EnergyInput
    {
        public static double Sinusoidal(int t)
        {
            return 10 + Math.Sin(t * 0.2) * 5;
        }

        public static double RandomGaussian(Random rng)
        {
            double u1 = 1.0 - rng.NextDouble();
            double u2 = 1.0 - rng.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                   Math.Sin(2.0 * Math.PI * u2);
            return 10 + randStdNormal * 2;
        }

        public static double StepFluctuation(int t)
        {
            if ((t / 20) % 2 == 0)
                return 15;
            else
                return 5;
        }

        public static double CatastrophicDrop(int t)
        {
            if (t == 30 || t == 70)
                return 2;
            else
                return 10 + Math.Sin(t * 0.15) * 3;
        }
    }
}

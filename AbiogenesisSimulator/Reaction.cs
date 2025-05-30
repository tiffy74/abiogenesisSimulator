using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbiogenesisSimulator
{
    public class Reaction
    {
        public string Name { get; set; }
        public double InputEnergy { get; set; }   // x
        public double OutputEnergy { get; set; }  // r
        public double StorageEnergy { get; set; } // s

        public double NetViability => OutputEnergy + StorageEnergy - InputEnergy;
    }
}

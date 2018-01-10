using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPTraining
{
    /// <summary>
    /// Data class to encapsulate a PSP phase
    /// </summary>
    public class Phase
    {
        public string Name { get; set; }
        public double Hours { get; set; }
        public double InjectionRate { get; set; }
        public double DefectsInjected { get; set; }
        public double DefectsPresent { get; set; }
        public double DefectsRemoved { get; set; }
        public double DefectsEscaping { get; set; }
        public double Yield { get; set; }

        public string ToCsv()
        {
            return $"{Name},{Hours},{InjectionRate.ToString("0.000")},{DefectsInjected.ToString("0.00")},{DefectsPresent.ToString("0.00")},{DefectsRemoved.ToString("0.00")},{DefectsEscaping.ToString("0.00")},{Yield * 100}%";
        }
    }
}

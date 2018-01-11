using System.Collections.Generic;
using System.IO;

namespace PSPTraining
{
    public class PhaseParser
    {
        public List<Phase> ParseData(string fileName)
        {
            var ret = new List<Phase>();

            foreach (var line in File.ReadAllLines(fileName))
            {
                var parts = line.Split(',');
                var phase = new Phase
                {
                    Name = parts[0],
                    Hours = double.Parse(parts[1]),
                    InjectionRate = double.Parse(parts[2]),
                    Yield = MikeMath.PercentageStringToDouble(parts[3])
                };

                ret.Add(phase);
            }

            return ret;
        }
    }
}

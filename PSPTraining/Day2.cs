using System.Linq;

namespace PSPTraining
{
    public class Day2
    {
        public static string Header = "Phase,Hours,Injection Rate,Defects Injected,Defects Present,Defects Removed,Defects Escaping Yield\n";
        public string CreateCsv(string inputFile)
        {
            var phases = new PhaseParser().ParseData(inputFile);
            for (int i = 0; i < phases.Count; i++)
            {
                var phase = phases[i];
                phase.DefectsInjected = phase.Hours * phase.InjectionRate;
                phase.DefectsPresent += phase.DefectsInjected;
                phase.DefectsRemoved = phase.Yield * phase.DefectsPresent;
                phase.DefectsEscaping = phase.DefectsPresent - phase.DefectsRemoved;

                if (i + 1 < phases.Count)
                {
                    phases[i + 1].DefectsPresent = phase.DefectsEscaping;
                }
            }

            return Header + string.Join("\n", phases.Select(p => p.ToCsv()));
        }
    }
}

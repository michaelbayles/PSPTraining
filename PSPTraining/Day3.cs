using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PSPTraining
{
    public class Day3
    {
        public static string Header = "Week Number,Plan Hours,Cumulative Plan Hours,Planned Value,Cumulative Planned Value\n";
        public static double DefaultHours = 15;

        public string CreateCsv(string inputFile)
        {
            var estimates = File.ReadAllLines(inputFile).Select(a => double.Parse(a)).ToList();
            var totalHours = estimates.Sum();

            List<Week> weeks = new List<Week>();
            Week currentWeek = new Week(DefaultHours, DefaultHours, DefaultHours, 0);
            weeks.Add(currentWeek);

            for (int i = 0; i < estimates.Count; i++)
            {
                var estimate = estimates[i];
                if (currentWeek.ConsumableHours - estimate >= 0)
                {
                    currentWeek.ConsumedHours += estimate;
                    currentWeek.ConsumableHours -= estimate;
                }
                else
                {
                    SubmitPlannedValue(totalHours, currentWeek);

                    var nextWeek = new Week(DefaultHours, currentWeek.CumulativePlanHours + DefaultHours, DefaultHours + currentWeek.ConsumableHours, currentWeek.CumulativePlannedValue);
                    currentWeek = nextWeek;
                    weeks.Add(currentWeek);

                    //replay this estimate
                    i--;
                }
            }

            //Need this once more so the very last week isn't forgotten
            SubmitPlannedValue(totalHours, currentWeek);

            string ret = Header;
            for (int i = 0; i < weeks.Count; i++)
            {
                //Output is 1 indexed
                ret += $"{i + 1},{weeks[i].ToCsv()}\n";
            }

            return ret;
        }

        private static void SubmitPlannedValue(double totalHours, Week currentWeek)
        {
            currentWeek.PlannedValue = currentWeek.ConsumedHours / totalHours;
            currentWeek.CumulativePlannedValue += currentWeek.PlannedValue;
        }
    }
}

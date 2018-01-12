using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPTraining
{
    public class EarnedValueCalculator
    {
        public static string Header = "Week Number,Planned Week Scheduled Hours,Actual Week Schedule Hours,Plan/Actual,Planned To Date Scheduled Hours,Actual To Date Schedule Hours,Plan/Actual," +
            "Planned Weekly Earned Value,Actual Weekly Earned Value,Plan/Actual,Planned To Date Earned Value,Actual To Date Earned Value,Plan/Actual," +
            "Planned To Date hours for tasks complete,Actual To Date hours for tasks complete,Planned/Actual\n";

        public List<Week> Weeks { get; }
        public List<Task> Tasks { get; }
        public EarnedValueCalculator(string plannedValueInput, string weeklyTaskDataFile, string weeklyActualsFile)
        {
            Weeks = new Day3().CreatePlannedValueWeeksFromInput(plannedValueInput);
            Tasks = new List<Task>();
            ParseTaskEstimates(plannedValueInput);
            ParseWeeklyTaskData(weeklyTaskDataFile);
            ParseWeeklyActuals(weeklyActualsFile);
            CalculateEarnedValues();
        }

        private void ParseTaskEstimates(string plannedValueInput)
        {
            var estimates = File.ReadAllLines(plannedValueInput).Select(a => double.Parse(a)).ToList();
            for (int i = 0; i < estimates.Count; i++)
            {
                Tasks.Add(new Task
                {
                    Id = i + 1,
                    Planned = estimates[i]
                });
            }
        }

        public string OutputCsv()
        {
            return Header + string.Join("\n", Weeks.Select(w => w.ToEvCsv()));
        }

        private void ParseWeeklyTaskData(string weeklyTaskDataFile)
        {
            foreach (var line in File.ReadAllLines(weeklyTaskDataFile))
            {
                var parts = line.Split(',').Select(p => double.Parse(p)).ToArray();
                var matchingWeek = Weeks.First(w => w.Number == parts[0]);
                var matchingTask = Tasks.FirstOrDefault(t => t.Id == parts[1]);

                if (matchingTask != null)
                {
                    matchingTask.Actual = parts[2];
                    matchingWeek.TasksCompleted.Add(matchingTask);
                }
            }
        }

        private void ParseWeeklyActuals(string weeklyActualsFile)
        {
            foreach (var line in File.ReadAllLines(weeklyActualsFile))
            {
                var parts = line.Split(',').Select(p => double.Parse(p)).ToArray();
                var matchingWeek = Weeks.First(w => w.Number == parts[0]);
                matchingWeek.ActualHours = parts[1];
                matchingWeek.CumulativeActualHours += matchingWeek.ActualHours;

                var nextWeek = Weeks.FirstOrDefault(w => w.Number == parts[0] + 1);
                if (nextWeek != null)
                {
                    nextWeek.CumulativeActualHours = matchingWeek.CumulativeActualHours;
                }
            }
        }

        private void CalculateEarnedValues()
        {
            var totalHours = Weeks.Sum(w => w.ConsumedHours);

            for (int i = 0; i < Weeks.Count; i++)
            {
                var week = Weeks[i];

                var totalPlanned = week.TasksCompleted.Sum(t => t.Planned);
                week.EarnedValue = totalPlanned / totalHours;

                week.CumulativeActualHoursCompleted += week.TasksCompleted.Sum(t => t.Actual);
                week.CumulativePlannedHoursCompleted += week.TasksCompleted.Sum(t => t.Planned);

                week.CumulativeEarnedValue += week.EarnedValue;

                if (i + 1 < Weeks.Count)
                {
                    Weeks[i + 1].CumulativeEarnedValue = week.CumulativeEarnedValue;
                    Weeks[i + 1].CumulativeActualHoursCompleted = week.CumulativeActualHoursCompleted;
                    Weeks[i + 1].CumulativePlannedHoursCompleted = week.CumulativePlannedHoursCompleted;
                }
            }
        }

        public double WeeksRemainingUsingCumulative(int asOfWeek)
        {
            var week = Weeks.FirstOrDefault(w => w.Number == asOfWeek);

            return Weeks.Sum(w => w.ConsumedHours) / ((week.CumulativeEarnedValue * 100) / asOfWeek);

        }
        public double WeeksRemainingUsingWeek(int asOfWeek)
        {
            var week = Weeks.FirstOrDefault(w => w.Number == asOfWeek);

            return Weeks.Sum(w => w.ConsumedHours) / (week.EarnedValue * 100);
        }
    }
}

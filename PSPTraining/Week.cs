using System.Collections.Generic;

namespace PSPTraining
{
    public class Week
    {
        public Week(double planHours, double cumulativePlanHours, double consumableHours, double cumulativePlannedValue)
        {
            PlanHours = planHours;
            CumulativePlanHours = cumulativePlanHours;
            ConsumableHours = consumableHours;
            CumulativePlannedValue = cumulativePlannedValue;
            TasksCompleted = new List<Task>();
        }

        public int Number { get; set; }
        public double PlanHours { get; set; }
        public double ActualHours { get; set; }
        public double CumulativePlanHours { get; set; }
        public double ConsumableHours { get; set; }
        public double ConsumedHours { get; set; }

        public double PlannedValue { get; set; }
        public double CumulativePlannedValue { get; set; }

        public double EarnedValue { get; set; }
        public double CumulativeEarnedValue { get; set; }
        public double CumulativActualHoursCompleted { get; set; }
        public double CumulativePlannedHoursCompleted { get; set; }
        public List<Task> TasksCompleted { get; }

        public string ToPvCsv()
        {
            return $"{PlanHours.ToString("0")},{CumulativePlanHours.ToString("0")},{(PlannedValue * 100).ToString("0.0")},{(CumulativePlannedValue * 100).ToString("0.0")}";
        }
    }
}

using System.Collections.Generic;

namespace PSPTraining
{
    public class Week
    {
        public Week(int number, double planHours, double cumulativePlanHours, double consumableHours, double cumulativePlannedValue)
        {
            Number = number;
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
        public double CumulativeActualHours { get; set; }
        public double ConsumableHours { get; set; }
        public double ConsumedHours { get; set; }
        public double PlannedValue { get; set; }
        public double CumulativePlannedValue { get; set; }
        public double EarnedValue { get; set; }
        public double CumulativeEarnedValue { get; set; }
        public double CumulativeActualHoursCompleted { get; set; }
        public double CumulativePlannedHoursCompleted { get; set; }
        public List<Task> TasksCompleted { get; }

        public string ToPvCsv()
        {
            return $"{PlanHours.ToString("0")},{CumulativePlanHours.ToString("0")},{(PlannedValue * 100).ToString("0.0")},{(CumulativePlannedValue * 100).ToString("0.0")}";
        }

        public string ToEvCsv()
        {
            return $"{Number},{PlanHours},{ActualHours},{(PlanHours / ActualHours).ToString("0.00")},{CumulativePlanHours},{CumulativeActualHours},{(CumulativePlanHours / CumulativeActualHours).ToString("0.00")},{(PlannedValue * 100).ToString("0.0")},{(EarnedValue * 100).ToString("0.0")},{(PlannedValue / EarnedValue).ToString("0.00")},{(CumulativePlannedValue * 100).ToString("0.0")},{(CumulativeEarnedValue * 100).ToString("0.0")},{(CumulativePlannedValue / CumulativeEarnedValue).ToString("0.00")},{CumulativePlannedHoursCompleted},{CumulativeActualHoursCompleted},{(CumulativePlannedHoursCompleted / CumulativeActualHoursCompleted).ToString("0.00")}";
        }
    }
}

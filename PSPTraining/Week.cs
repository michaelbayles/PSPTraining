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
        }

        public double PlanHours { get; set; }
        public double ConsumableHours { get; set; }
        public double ConsumedHours { get; set; }
        public double CumulativePlanHours { get; set; }
        public double PlannedValue { get; set; }
        public double CumulativePlannedValue { get; set; }

        public string ToCsv()
        {
            return $"{PlanHours.ToString("0")},{CumulativePlanHours.ToString("0")},{(PlannedValue * 100).ToString("0.0")},{(CumulativePlannedValue * 100).ToString("0.0")}";
        }
    }
}

# Day 3 Design

## Basic Logic

1. Read input data
1. Parse the task data into `List<double>`
1. Calculate sum of all tasks
1. Create `List<Week>` that will be used later for output
1. Foreach task estimate:
    1. If current task fits in current week (`ConsumableHours` - task estimate > 0)
        1. Add the task estimate to `ConsumedHours`
        1. Remove task estimate from `ConsumableHours`
    1. Else
        1. Set `PlannedValue` to `ConsumedHours / TotalHours`
        1. Add `PlannedValue` to `CumulativePlanHours`
        1. Create a new `Week` with `PlanHours` = `DefaultPlanHours`
        1. Set `ConsumableHours` = `DefaultPlanHours` + `currentWeek.ConsumableHours`
        1. Set `CumulativePlannedValue` to `currentWeek.CumulativePlanHours`
        1. Set `currentWeek` to newly created `Week`
1. Output the `List<Week>` as a CSV


## Week Class Definition

```
public class Week
{
    public int Number { get; set; }
    public double PlanHours { get; set; }
    public double ConsumableHours { get; set; }
    public double ConsumedHours { get; set; }
    public double CumulativePlanHours { get; set; }
    public double PlannedValue { get; set; }
    public double CumulativePlannedValue { get; set; }
    
}
```

# Day 4 Design

## Basic Logic

1. Read task estimate input data and pass in to `CreatePlannedValueWeeksFromInput` to get a `List<Week>` with planned value calculated for each `Week`
1. Parse the weekly task data and update each `Week` object with its corresponding `Task`s based on the `Number` property
1. Parse the weekly actual hours and update each `Week` object with its corresponding `ActualHours`
1. Add `ActualHours` to `CumulativeActualHours` and set the next `Week`'s `CumulativeActualHours` to the current `CumulativeActualHours`
1. Foreach `Task` that has been completed in a `Week`:
    1. Sum up `Planned` and divide by the sum of all total hours and set as `EarnedValue`
    1. Add `Actual` to `CumulativeActualHoursCompleted`
    1. Add `Planned` to `CumulativePlannedHoursCompleted`
1. Foreach `Week`:
    1. Add `EarnedValue` to `CumulativeEarnedValue`
    1. Set `CumulativeEarnedValue` of next `Week` to current `CumulativeEarnedValue`

1. Output the `List<Week>` as a CSV using the `ToEvCsv()` method. This method will be able to calculate planned/actual on the fly so we don't have to store them

### EarnedValueCalculator Class Definition

```
public class EarnedValueCalculator
{
    public double WeeksRemainingUsingCumulative(int asOfWeek)
    public double WeeksRemainingUsingWeek(int asOfWeek)
}
```

## Week Class Definition

```
public class Week
{
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
    public string ToEvCsv()
}
```

## Task Class Definition

```
public class Task
{
    public string Name { get; set; }
    public double Planned { get; set; }
    public double Actual { get; set; }
}
```

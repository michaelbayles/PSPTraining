# Day 2 Design

## Basic Logic

1. Read input data
1. Parse the data and create a new `Phase` object for each line
1. Add object to `List<Phase>`
1. After all input is processed, iterate through the `List<Phase>` and apply each calculation
    1. Multiply `Hours` by `InjectionRate` and set to `DefectsInjected`
    1. Add `DefectsInjected` to `DefectsPresent`
    1. Multiply `Yield` by `DefectsPresent` and set to `DefectsRemoved`
    1. Subtract `DefectsRemoved` from `DefectsPresent` and set to `DefectsEscaping`
    1. Add `DefectsEscaping` to `DefectsPresent` of next `Phase` object
1. Output the `List<Phase>` as a CSV


## Phase Class Definition

```
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
}
```

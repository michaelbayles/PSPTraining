using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPTraining;

namespace PSPTrainingTests
{
    [TestClass]
    public class EarnedValueCalculatorTests
    {
        [TestMethod]
        public void TestDavisEvRawData()
        {
            var calculator = new EarnedValueCalculator("EV.txt", "weeklyTaskData.txt", "weeklyActuals.txt");

            Assert.AreEqual(2, calculator.Weeks[2].TasksCompleted.Count);
            Assert.AreEqual(15, calculator.Weeks[2].PlanHours);
            Assert.AreEqual(13, calculator.Weeks[2].ActualHours);
            Assert.AreEqual(45, calculator.Weeks[2].CumulativePlanHours);
            Assert.AreEqual(39, calculator.Weeks[2].CumulativeActualHours);
        }

        [TestMethod]
        public void TestDavisEvCsvData()
        {
            var calculator = new EarnedValueCalculator("EV.txt", "weeklyTaskData.txt", "weeklyActuals.txt");
            var csv = calculator.OutputCsv();
            var rows = csv.Split('\n');

            Assert.AreEqual(EarnedValueCalculator.Header, rows[0] + '\n');
            Assert.AreEqual("3,15,13,1.15,45,39,1.15,20.3,23.4,0.87,67.2,42.2,1.59,27,31,0.87", rows[3]);
        }

        [TestMethod]
        public void TestProjection1()
        {
            var calculator = new EarnedValueCalculator("EV.txt", "weeklyTaskData.txt", "weeklyActuals.txt");

            Assert.AreEqual(4.1, calculator.WeeksRemainingUsingCumulative(3), 0.5);
        }


        [TestMethod]
        public void TestProjection2()
        {
            var calculator = new EarnedValueCalculator("EV.txt", "weeklyTaskData.txt", "weeklyActuals.txt");

            Assert.AreEqual(2.5, calculator.WeeksRemainingUsingWeek(3), 0.5);
        }
    }
}

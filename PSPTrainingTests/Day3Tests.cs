using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPTraining;

namespace PSPTrainingTests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void TestDavisEvData()
        {
            var csv = new Day3().CreatePlannedValueCsv("EV.txt");
            var rows = csv.Split('\n');

            Assert.AreEqual(Day3.Header, rows[0] + '\n');
            Assert.AreEqual("1,15,15,18.8,18.8", rows[1]);
            Assert.AreEqual("2,15,30,28.1,46.9", rows[2]);
            Assert.AreEqual("3,15,45,20.3,67.2", rows[3]);
            Assert.AreEqual("4,15,60,26.6,93.8", rows[4]);
            Assert.AreEqual("5,15,75,6.3,100.0", rows[5]);
        }
    }
}

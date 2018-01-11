using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPTraining;

namespace PSPTrainingTests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void TestDavisQualityData()
        {
            var csv = new Day2().CreateCsv("Day2Input.txt");
            var rows = csv.Split('\n');
            Assert.AreEqual(Day2.Header, rows[0] + '\n');

            Assert.AreEqual("HLD,10,0.250,2.50,2.50,0.00,2.50,0%", rows[1]);
            Assert.AreEqual("HLDR,0,0.000,0.00,2.50,1.75,0.75,70%", rows[2]);
            Assert.AreEqual("HLD Insp,0,0.000,0.00,0.75,0.53,0.23,70%", rows[3]);
            Assert.AreEqual("DLD,15,0.750,11.25,11.48,0.00,11.48,0%", rows[4]);
            Assert.AreEqual("DLDR,0,0.000,0.00,11.48,8.03,3.44,70%", rows[5]);
            Assert.AreEqual("DLD Insp,0,0.000,0.00,3.44,2.41,1.03,70%", rows[6]);
            Assert.AreEqual("Code,15,0.800,12.00,13.03,0.00,13.03,0%", rows[7]);
            Assert.AreEqual("CR,0,0.000,0.00,13.03,9.12,3.91,70%", rows[8]);
            Assert.AreEqual("C Insp,0,0.000,0.00,3.91,2.74,1.17,70%", rows[9]);
            Assert.AreEqual("UT,10,0.067,0.67,1.84,0.92,0.92,50%", rows[10]);
            Assert.AreEqual("IT,0,0.000,0.00,0.92,0.46,0.46,50%", rows[11]);
            Assert.AreEqual("ST,0,0.000,0.00,0.46,0.23,0.23,50%", rows[12]);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPTraining;

namespace PSPTrainingTests
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void TestDavisData()
        {
            Assert.AreEqual(51, new Day1().CalculateMedianFromFile("Day1Input.txt"));
        }
    }
}

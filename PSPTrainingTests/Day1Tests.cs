using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPTraining;
using System.IO;

namespace PSPTrainingTests
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void TestDavisMedianData()
        {
            Assert.AreEqual(51, new Day1().CalculateMedianFromFile("Day1Input.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestFileNotFound()
        {
            new Day1().CalculateMedianFromFile("asdf.txt");
        }
    }
}

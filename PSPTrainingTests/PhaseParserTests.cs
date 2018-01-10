using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PSPTraining;
using System.Collections.Generic;

namespace PSPTrainingTests
{
    [TestClass]
    public class PhaseParserTests
    {
        [TestMethod]
        public void TestNoData()
        {
            var fileName = "blank.txt";
            File.CreateText(fileName).Close();
            CollectionAssert.AreEqual(new List<Phase>(), new PhaseParser().ParseData(fileName));
        }

        [TestMethod]
        public void TestSimpleData()
        {
            var fileName = "simple.txt";
            File.WriteAllLines(fileName, new string[] { "HLD,10,0.250,0%", "HLDR,0,0.000,70%", "UT,10,0.067,50%" });

            var phases = new PhaseParser().ParseData(fileName);

            Assert.AreEqual(3, phases.Count);
            Assert.AreEqual("HLD", phases[0].Name);
            Assert.AreEqual(10, phases[0].Hours);
            Assert.AreEqual(0.25, phases[0].InjectionRate);
            Assert.AreEqual(0, phases[0].Yield);
            
            Assert.AreEqual("UT", phases[2].Name);
            Assert.AreEqual(10, phases[2].Hours);
            Assert.AreEqual(0.067, phases[2].InjectionRate);
            Assert.AreEqual(0.5, phases[2].Yield);

        }
    }
}

﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPTraining;

namespace PSPTrainingTests
{
    [TestClass]
    public class MikeMathTests
    {
        [TestMethod]
        public void Test0Elements()
        {
            Assert.AreEqual(0, MikeMath.Median(new int[] { }));
        }

        [TestMethod]
        public void Test1Element()
        {
            Assert.AreEqual(2, MikeMath.Median(new int[] { 2 }));
        }

        [TestMethod]
        public void TestEvenElements()
        {
            Assert.AreEqual(3.5, MikeMath.Median(new int[] { 1, 2, 5, 10 }));
        }

        [TestMethod]
        public void TestOddElements()
        {
            Assert.AreEqual(3, MikeMath.Median(new int[] { 2, 3, 4 }));
        }

        [TestMethod]
        public void TestCanParsePercentage()
        {
            Assert.AreEqual(0.3, MikeMath.PercentageStringToDouble("30%"));
        }

        [TestMethod]        
        public void TestNoPercentageFound()
        {
            Assert.AreEqual(0, MikeMath.PercentageStringToDouble("adsf"));
        }
    }
}

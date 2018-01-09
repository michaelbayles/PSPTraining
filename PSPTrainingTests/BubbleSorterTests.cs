using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPTrainingTests
{
    [TestClass]
    public class BubbleSorterTests
    {
        [TestMethod]
        public void Test1Number()
        {
            CollectionAssert.AreEqual(new int[] { 1 }, BubbleSorter.SortInts(new int[] { 1 }));
        }

        [TestMethod]
        public void TestSameNumber()
        {
            CollectionAssert.AreEqual(new int[] { 1, 1 }, BubbleSorter.SortInts(new int[] { 1, 1 }));
        }

        [TestMethod]
        public void TestAlreadySorted()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, BubbleSorter.SortInts(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void TestNastyNumbers()
        {
            CollectionAssert.AreEqual(new int[] { 2, 19, 40 }, BubbleSorter.SortInts(new int[] { 19, 2, 40 }));
        }
    }
}

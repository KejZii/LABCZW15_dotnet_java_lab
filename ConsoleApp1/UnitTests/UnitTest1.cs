using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestItemFits()
        {
            Problem problem = new Problem(5, 1);
            Result result = problem.Solve(10);
            Assert.IsTrue(result.itemsInSuc.Count > 0);
        }

        [TestMethod]
        public void TestNoItemFits()
        {
            Problem problem = new Problem(5, 42);
            Result result = problem.Solve(0);
            Assert.AreEqual(0, result.itemsInSuc.Count);
            Assert.AreEqual(0, result.valueSum);
            Assert.AreEqual(0, result.wageSum);
        }
    }
}
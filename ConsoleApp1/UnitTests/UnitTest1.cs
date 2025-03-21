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

        [TestMethod]
        public void TestItemValue()
        {
            int testValue = 5;
            Problem problem = new Problem();
            Result result = problem.Solve(testValue);
            Assert.AreEqual(5, result.valueSum);
        }

        [TestMethod]
        public void TestItemsAmount()
        {
            int testValue = 2;
            Problem problem = new Problem();
            Result result = problem.Solve(testValue);
            Assert.AreEqual(testValue, result.itemsInSuc.Count);
        }

        [TestMethod]
        public void TestIsListEmpty()
        {
            Problem problem = new Problem(0,1);
            Result result = problem.Solve(0);
            Assert.IsTrue(result.itemsInSuc.Count == 0);
        }
    }
}
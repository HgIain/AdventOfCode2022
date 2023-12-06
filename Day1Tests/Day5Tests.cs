using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Tests
{
    [TestClass()]
    public class Day5Tests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var day5 = new SupplyStacks("Day5TestInput.txt");
            var result = day5.Process();
            Assert.AreEqual("CMZ",result);
        }
        [TestMethod()]
        public void ProcessTestFullData()
        {
            var day5 = new SupplyStacks("Day5Input.txt");
            var result = day5.Process();
            Assert.AreEqual("SHMSDGZVC", result);
        }

        [TestMethod()]
        public void ProcessTestMulticrate()
        {
            var day5 = new SupplyStacks("Day5TestInput.txt");
            var result = day5.Process(true);
            Assert.AreEqual("MCD", result);
        }
        [TestMethod()]
        public void ProcessTestMulticrateFullData()
        {
            var day5 = new SupplyStacks("Day5Input.txt");
            var result = day5.Process(true);
            Assert.AreEqual("VRZGHDFBQ", result);
        }
    }
}
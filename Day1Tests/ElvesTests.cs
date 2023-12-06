using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Day1.Tests
{
    [TestClass()]
    public class ElvesTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var elves = new Elves("Day1TestInput.txt");
            var result = elves.Process(1);

            Assert.AreEqual(24000, result);
        }
        [TestMethod()]
        public void ProcessTestFullData()
        {
            var elves = new Elves("Day1Input.txt");
            var result = elves.Process(1);

            Assert.AreEqual(72240, result);
        }
        [TestMethod()]
        public void ProcessTest3()
        {
            var elves = new Elves("Day1TestInput.txt");
            var result = elves.Process(3);

            Assert.AreEqual(45000, result);
        }
        [TestMethod()]
        public void ProcessTest3FullData()
        {
            var elves = new Elves("Day1Input.txt");
            var result = elves.Process(3);

            Assert.AreEqual(210957, result);
        }
    }
}
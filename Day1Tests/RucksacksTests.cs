using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Tests
{
    [TestClass()]
    public class RucksacksTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var rucksacks = new Rucksacks("Day3TestInput.txt");
            var result = rucksacks.Process();
            Assert.AreEqual(157, result);
        }

        [TestMethod()]
        public void ProcessTestFullData()
        {
            var rucksacks = new Rucksacks("Day3Input.txt");
            var result = rucksacks.Process();
            Assert.AreEqual(7785, result);
        }

        [TestMethod()]
        public void ProcessGroups()
        {
            var rucksacks = new Rucksacks("Day3TestInput.txt");
            var result = rucksacks.ProcessGroups();
            Assert.AreEqual(70, result);
        }

        [TestMethod()]
        public void ProcessGroupsFullData()
        {
            var rucksacks = new Rucksacks("Day3Input.txt");
            var result = rucksacks.ProcessGroups();
            Assert.AreEqual(2633, result);
        }
    }
}
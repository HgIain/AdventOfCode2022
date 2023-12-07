using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Tests
{
    [TestClass()]
    public class Day8Tests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var treeGrid = new TreeGrid("Day8TestInput.txt");
            var result = treeGrid.Process();
            Assert.AreEqual(21, result);
        }
        [TestMethod()]
        public void ProcessTestFullData()
        {
            var treeGrid = new TreeGrid("Day8Input.txt");
            var result = treeGrid.Process();
            Assert.AreEqual(1792, result);
        }

        [TestMethod()]
        public void ProcessBestScore()
        {
            var treeGrid = new TreeGrid("Day8TestInput.txt");
            var result = treeGrid.Process(true);
            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void ProcessBestScoreFullData()
        {
            var treeGrid = new TreeGrid("Day8Input.txt");
            var result = treeGrid.Process(true);
            Assert.AreEqual(334880, result);
        }
    }
}
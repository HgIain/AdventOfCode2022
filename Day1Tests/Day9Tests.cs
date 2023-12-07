using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Tests
{
    [TestClass()]
    public class Day9Tests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var rope = new RopeTracker("Day9TestInput.txt");
            var result = rope.Process();
            Assert.AreEqual(13, result);
        }
        [TestMethod()]
        public void ProcessTestFullData()
        {
            var rope = new RopeTracker("Day9Input.txt");
            var result = rope.Process();
            Assert.AreEqual(6486, result);
        }

        [TestMethod()]
        public void ProcessTestLongRope()
        {
            var rope = new RopeTracker("Day9TestInput.txt");
            var result = rope.Process(10);
            Assert.AreEqual(1, result);
        }
        [TestMethod()]
        public void ProcessTestLongRopeV2()
        {
            var rope = new RopeTracker("Day9TestInput2.txt");
            var result = rope.Process(10);
            Assert.AreEqual(36, result);
        }
        [TestMethod()]
        public void ProcessTestLongRopeFullData()
        {
            var rope = new RopeTracker("Day9Input.txt");
            var result = rope.Process(10);
            Assert.AreEqual(2678, result);
        }
    }
}
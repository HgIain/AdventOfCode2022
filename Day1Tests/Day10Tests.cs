using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Tests
{
    [TestClass()]
    public class Day10Tests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var signal = new SignalStrength("Day10TestInput.txt");
            var result = signal.Process();
            Assert.AreEqual(13140, result);
        }

        [TestMethod()]
        public void ProcessTestFullData()
        {
            var signal = new SignalStrength("Day10Input.txt");
            var result = signal.Process();
            Assert.AreEqual(14620, result);
        }
    }
}
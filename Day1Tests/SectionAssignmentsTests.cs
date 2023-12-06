using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Tests
{
    [TestClass()]
    public class SectionAssignmentsTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var assignments = new SectionAssignments("Day4TestInput.txt");
            var result = assignments.Process();

            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void ProcessTestFullData()
        {
            var assignments = new SectionAssignments("Day4Input.txt");
            var result = assignments.Process();

            Assert.AreEqual(498, result);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6.Tests
{
    [TestClass()]
    public class Day6Tests
    {
        [TestMethod()]
        public void ProcessRadio1()
        {
            var result = Radio.Process("mjqjpqmgbljsphdztnvjfqwrcgsmlb",4);
            Assert.AreEqual(7,result);
        }

        [TestMethod()]
        public void ProcessRadio2()
        {
            var result = Radio.Process("bvwbjplbgvbhsrlpgdmjqwftvncz", 4);
            Assert.AreEqual(5, result);
        }
        [TestMethod()]
        public void ProcessRadio3()
        {
            var result = Radio.Process("nppdvjthqldpwncqszvftbrmjlhg", 4);
            Assert.AreEqual(6, result);
        }
        [TestMethod()]
        public void ProcessRadio4()
        {
            var result = Radio.Process("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4);
            Assert.AreEqual(10, result);
        }
        [TestMethod()]
        public void ProcessRadio41()
        {
            var result = Radio.Process("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4);
            Assert.AreEqual(11, result);
        }
        [TestMethod()]
        public void ProcessRadio5()
        {
            var result = Radio.ProcessFile("Day6Input.txt", 4);
            Assert.AreEqual(1816, result);
        }
        [TestMethod()]
        public void ProcessRadio6()
        {
            var result = Radio.Process("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14);
            Assert.AreEqual(19, result);
        }
        [TestMethod()]
        public void ProcessRadio7()
        {
            var result = Radio.Process("bvwbjplbgvbhsrlpgdmjqwftvncz", 14);
            Assert.AreEqual(23, result);
        }
        [TestMethod()]
        public void ProcessRadio8()
        {
            var result = Radio.Process("nppdvjthqldpwncqszvftbrmjlhg", 14);
            Assert.AreEqual(23, result);
        }
        [TestMethod()]
        public void ProcessRadio9()
        {
            var result = Radio.Process("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14);
            Assert.AreEqual(29, result);
        }
        [TestMethod()]
        public void ProcessRadio10()
        {
            var result = Radio.Process("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14);
            Assert.AreEqual(26, result);
        }
        [TestMethod()]
        public void ProcessRadio11()
        {
            var result = Radio.ProcessFile("Day6Input.txt", 14);
            Assert.AreEqual(2625, result);
        }
    }
}
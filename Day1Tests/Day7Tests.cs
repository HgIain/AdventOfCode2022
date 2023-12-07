using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Tests
{
    [TestClass()]
    public class Day7Tests
    {
        [TestMethod()]
        public void ProcessSmallDir()
        {
            var fileSystem = new ElfFileSystem("Day7TestInput.txt");
            var result = fileSystem.Process(false);
            Assert.AreEqual(95437, result);
        }
        [TestMethod()]
        public void ProcessSmallDirFullData()
        {
            var fileSystem = new ElfFileSystem("Day7Input.txt");
            var result = fileSystem.Process(false);
            Assert.AreEqual(1428881, result);
        }
        [TestMethod()]
        public void ProcessDeleteSpace()
        {
            var fileSystem = new ElfFileSystem("Day7TestInput.txt");
            var result = fileSystem.Process(true);
            Assert.AreEqual(24933642, result);
        }
        [TestMethod()]
        public void ProcessDeleteSpaceFullData()
        {
            var fileSystem = new ElfFileSystem("Day7Input.txt");
            var result = fileSystem.Process(true);
            Assert.AreEqual(10475598, result);
        }
    }
}
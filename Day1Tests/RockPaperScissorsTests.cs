using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2;


namespace Day2.Tests
{
    [TestClass()]
    public class RockPaperScissorsTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            var rps = new RockPaperScissors("Day2TestInput.txt");
            var result = rps.Process(false);

            Assert.AreEqual(15, result);
        }
        [TestMethod()]
        public void ProcessTestFullData()
        {
            var rps = new RockPaperScissors("Day2Input.txt");
            var result = rps.Process(false);

            Assert.AreEqual(10941, result);
        }

        [TestMethod()]
        public void ProcessTestV2()
        {
            var rps = new RockPaperScissors("Day2TestInput.txt");
            var result = rps.Process(true);

            Assert.AreEqual(12, result);
        }
        [TestMethod()]
        public void ProcessTestV2FullData()
        {
            var rps = new RockPaperScissors("Day2Input.txt");
            var result = rps.Process(true);

            Assert.AreEqual(13071, result);
        }
    }
}
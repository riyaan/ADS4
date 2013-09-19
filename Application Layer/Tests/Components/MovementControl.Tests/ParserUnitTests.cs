using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovementControl.Tests
{
    [TestClass]
    public class ParserUnitTests
    {
        [TestMethod]
        public void ParseSuccess()
        {
            Parser parser = new Parser();
            ExpressionBase eb = parser.Parse("F2");

            Assert.AreNotEqual(null, eb);
        }
    }
}

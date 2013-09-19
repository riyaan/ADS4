using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MovementControl.Tests
{
    [TestClass]
    public class ParserUnitTests
    {
        [TestMethod]
        public void ParseSuccess()
        {
            Parser parser = new Parser();
            List<Context> context = parser.Parse("F2U5L6");

            Assert.AreNotEqual(null, context);
        }
    }
}

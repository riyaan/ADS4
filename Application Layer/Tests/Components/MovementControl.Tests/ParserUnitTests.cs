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

            Assert.AreNotEqual(0, context.Count);
        }

        [TestMethod]
        public void ParseFailure()
        {
            Parser parser = new Parser();
            List<Context> context = parser.Parse("2U5X6EE");

            Assert.AreEqual(0, context.Count);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities.Tests
{
    [TestClass]
    public class ArrowUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ArrowContext arrow = new ArrowContext(new ConcreteStateNorth());
            arrow.MoveEast();
            arrow.MoveEast();
            arrow.MoveWest();
        }
    }
}

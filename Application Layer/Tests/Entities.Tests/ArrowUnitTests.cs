using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities.Tests
{
    [TestClass]
    public class ArrowUnitTests
    {
        [TestMethod]
        public void CreateArrowSuccess()
        {
            ArrowContext arrow = new ArrowContext(new ConcreteStateForward());
            arrow.Right();
            arrow.Right();
            arrow.Left();
        }
    }
}

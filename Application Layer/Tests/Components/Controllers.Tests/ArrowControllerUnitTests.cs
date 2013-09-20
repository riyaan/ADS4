using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Controllers.Tests
{
    [TestClass]
    public class ArrowControllerUnitTests
    {
        [TestMethod]
        public void MovementSuccess()
        {
            ArrowController ac = new ArrowController();
            ac.Right(5);
            ac.Left(2);
            ac.Forward(3);

            Assert.AreNotEqual(0, ac.Arrow.X);
        }
    }
}

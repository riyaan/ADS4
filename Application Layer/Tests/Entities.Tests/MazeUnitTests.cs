using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entities.Tests
{
    [TestClass]
    public class MazeUnitTests
    {
        [TestMethod]
        public void CreateMazeSuccess()
        {
            Maze maze = new Maze(3, 3);
            Assert.AreNotEqual(0, maze.Grid.Length);
        }
    }
}

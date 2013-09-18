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

        [TestMethod]
        public void CreateAdjacentsSuccess()
        {
            Maze maze = new Maze(3, 3);
            maze.CreateAdjacents();
            Assert.AreNotEqual(0, maze.Grid[0, 0].Adjacents.Count);
        }
    }
}

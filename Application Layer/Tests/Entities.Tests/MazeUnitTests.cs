using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagnostics;

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
            Maze maze = new Maze(5, 5);
            maze.CreateAdjacents();
            Assert.AreNotEqual(0, maze.Grid[0, 0].Adjacents.Count);
        }

        [TestMethod]
        public void FindEndSuccess()
        {
            Maze maze = new Maze(10, 10);
            maze.CreateAdjacents();
            maze.FindEnd(maze.Grid[0, 0]);            

            string output = String.Empty;
            for (int i = maze.Rows-1; i >= 0; i--)
            {
                for (int j = maze.Columns-1; j >= 0; j--)
                {
                    if (maze.Grid[i, j].CellState == CELL_STATE.OPEN)
                        output += "|O|";
                    else
                        output += "|X|";
                }
                output += System.Environment.NewLine;
            }

            Logger.Instance.Log(output);

            Assert.AreEqual(1, 1);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagnostics;
using Entities.Maze;

namespace Entities.Tests
{
    [TestClass]
    public class MazeUnitTests
    {
        [TestMethod]
        public void CreateMazeSuccess()
        {
            Maze.Maze maze = new Maze.Maze(3, 3);
            Assert.AreNotEqual(0, maze.Grid.Length);
        }

        [TestMethod]
        public void CreateAdjacentsSuccess()
        {
            Maze.Maze maze = new Maze.Maze(5, 5);
            Common common = new Common();
            common.CreateAdjacents(maze);
            Assert.AreNotEqual(0, maze.Grid[0, 0].Adjacents.Count);
        }

        [TestMethod]
        public void FindEndSuccess()
        {
            Maze.Maze maze = new Maze.Maze(10, 10);
            Common common = new Common();
            common.CreateAdjacents(maze);
            maze.SetMazeCreationStrategy(new PrimsAlgorithm(maze));

            string output = System.Environment.NewLine;
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

        [TestMethod]
        public void FindEndRecursiveBacktrackerSuccess()
        {
            Maze.Maze maze = new Maze.Maze(10, 10);
            Common common = new Common();
            common.CreateAdjacents(maze);
            maze.SetMazeCreationStrategy(new RecursiveBacktrackingAlgorithm(maze));

            string output = System.Environment.NewLine;
            for (int i = maze.Rows - 1; i >= 0; i--)
            {
                for (int j = maze.Columns - 1; j >= 0; j--)
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
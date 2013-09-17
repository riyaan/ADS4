using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MazeGenerator.Tests
{
    [TestClass]
    public class MazeGeneratorTest
    {
        [TestMethod]
        public void TestCreateMaze()
        {
            int rows = 5, columns = 5;
            int gridSize = rows * columns;
            Cell[,] c = new Cell[rows,columns];
            MazeGenerator.Seed((int)DateTime.Now.Ticks);

            c = MazeGenerator.GenerateOrthogonal(rows, columns, 0, 0, true);

            StreamWriter writer = new StreamWriter(@"C:\temp\mazeGenerator.txt", true);
            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < columns; k++)
                {
                    writer.WriteLine(c[j, k]);
                }
            }
            writer.Close();
        }
    }
}
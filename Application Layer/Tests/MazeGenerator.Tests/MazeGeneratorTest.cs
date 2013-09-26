using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MazeGenerator.Tests
{
    [TestClass]
    public class MazeGeneratorTest
    {
        [TestMethod]        
        public void MazeGeneratorCreateMaze()
        {
            int rows = 5, columns = 5;
            int gridSize = rows * columns;
            Cell[,] c = new Cell[rows,columns];
            MazeGenerator.Seed((int)DateTime.Now.Ticks);

            c = MazeGenerator.GenerateOrthogonal(rows, columns, 0, 0, false);

            
            string output = System.Environment.NewLine;
            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < columns; k++)
                {
                    if(c[j, k].ClassState == CLASS_STATE.OPEN)
                        output += "|O|";
                    else
                        output += "|X|";
                    //writer.WriteLine(c[j, k]);
                }
            }
            StreamWriter writer = new StreamWriter(@"C:\temp\mazeGenerator.txt", true);
            writer.Write(output);
            writer.Close();
        }
    }
}
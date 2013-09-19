using Diagnostics;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    // TODO: Make this a singleton as well?
    public class MazeController
    {
        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int columns;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private Maze maze;

        public Maze Maze
        {
            get { return maze; }
            set { maze = value; }
        }

        public MazeController(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            CreateMaze(Rows, Columns);
        }

        private void CreateMaze(int rows, int columns)
        {
            Maze = new Maze(rows, columns);
            Maze.CreateAdjacents();
            Maze.FindEnd(maze.Grid[0, 0]);

            string output = String.Empty;
            for (int i = Maze.Rows - 1; i >= 0; i--)
            {
                for (int j = Maze.Columns - 1; j >= 0; j--)
                {
                    if (Maze.Grid[i, j].CellState == CELL_STATE.OPEN)
                        output += "|O|";
                    else
                        output += "|X|";
                }
                output += System.Environment.NewLine;
            }

            Logger.Instance.Log(output);
        }
    }
}

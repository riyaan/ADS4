using Diagnostics;
using Entities;
using Entities.Maze;
using System.Configuration;

namespace Controllers
{
    // TODO: Make this a singleton as well? (Singleton Design Pattern)
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

            string algorithm = ConfigurationManager.AppSettings["mazeAlgorithm"];

            if(algorithm.Equals("prim"))
                Maze.SetMazeCreationStrategy(new PrimsAlgorithm(Maze));
            else if(algorithm.Equals("recursiveBacktracking"))
                Maze.SetMazeCreationStrategy(new RecursiveBacktrackingAlgorithm(Maze));

            Maze.CreateMaze();

            // Maze.FindEnd(maze.Grid[0, 0]);
            //Maze.FindEndRecursiveBacktracker(maze.Grid[0, 0]);

            PrintMaze();
        }

        /// <summary>
        /// TODO: Disable this method when debugging is complete.
        /// Prints a textual representation of the maze.
        /// This is for Debugging purposes.
        /// </summary>
        private void PrintMaze()
        {
            string output = System.Environment.NewLine;
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

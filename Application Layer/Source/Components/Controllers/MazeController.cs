using Diagnostics;
using Entities;
using Entities.Maze;
using System.Configuration;

namespace Controllers
{
    // TODO: Make this a singleton as well? (Singleton Design Pattern)
    public class MazeController
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Maze Maze { get; set; }

        private Common _common;

        public MazeController(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            CreateMaze(Rows, Columns);            
        }

        private void CreateMaze(int rows, int columns)
        {
            Maze = new Maze(rows, columns);

            _common = new Common();
            _common.CreateAdjacents(Maze);

            ConfigurationManager.RefreshSection("appSettings");
            string algorithm = ConfigurationManager.AppSettings["mazeAlgorithm"];

            // TODO: Store these 'magic values' somewhere
            if(algorithm.Equals("prim"))
                Maze.SetMazeCreationStrategy(new PrimsAlgorithm(Maze));
            else if(algorithm.Equals("recursiveBacktracking"))
                Maze.SetMazeCreationStrategy(new RecursiveBacktrackingAlgorithm(Maze));
            else if (algorithm.Equals("custom"))
                Maze.SetMazeCreationStrategy(new CustomAlgorithm(Maze));

            Maze.CreateMaze();

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

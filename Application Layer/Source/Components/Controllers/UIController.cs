using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UIController
    {
        public UIController()
        {
        }

        public Maze GenerateNewMaze(int rows, int columns)
        {
            // UI Controller interacts with the Maze Controller
            MazeController mazeController = new MazeController(rows, columns);
            return mazeController.Maze;
        }
    }
}

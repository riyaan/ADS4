using Entities;
using MovementControl;

namespace Controllers
{
    public class UIController
    {
        private MazeController _mazeController;
        private MCLController _mclController;
        private ArrowController _arrowController;

        public UIController()
        {
        }

        public Maze GenerateNewMaze(int rows, int columns)
        {
            // UI Controller interacts with the Maze Controller
            _mazeController = new MazeController(rows, columns);
            return _mazeController.Maze; // return the maze for display purposes
        }

        public void ParseCommand(string command, out int x, out int y, out string direction)
        {
            // UI Controller interacts with the MCL Controller
            _mclController = new MCLController();
            _mclController.ParseCommand(command);

            _arrowController = new ArrowController(_mazeController.Maze.Rows, _mazeController.Maze.Columns);

            direction = string.Empty;
            // Execute each command
            foreach (Context context in _mclController.Context)
            {                
                switch (context.Direction)
                {
                    case "R":
                        _arrowController.Right(context.Steps);                        
                        break;
                    case "L":
                        _arrowController.Left(context.Steps);
                        break;
                    case "U":
                        _arrowController.Forward(context.Steps);
                        break;
                }
                direction = context.Direction;
            }

            // return the coordinates of the arrow
            x = _arrowController.Arrow.X;
            y = _arrowController.Arrow.Y;            
        }

        public void UpdateTheGrid()
        {

        }
    }
}
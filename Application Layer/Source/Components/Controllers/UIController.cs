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

            _arrowController = new ArrowController(_mazeController.Maze.Rows, _mazeController.Maze.Columns);
            _mclController = new MCLController();

            return _mazeController.Maze; // return the maze for display purposes
        }

        public void ParseCommand(string command, out int x, out int y, out string direction)
        {
            // UI Controller interacts with the MCL Controller            
            _mclController.ParseCommand(command);            

            direction = string.Empty;
            // Execute each command
            foreach (Context context in _mclController.Context)
            {                
                switch (context.Direction)
                {
                    case "R":
                        _arrowController.Right(context.Steps);
                        // Update the grid
                        OnMazeChanged(new MazeChangedEventArgs());
                        break;
                    case "L":
                        _arrowController.Left(context.Steps);
                        break;
                    case "F":
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
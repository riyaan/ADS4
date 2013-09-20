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

        public void ParseCommand(string command)
        {
            // UI Controller interacts with the MCL Controller
            _mclController = new MCLController();
            _mclController.ParseCommand(command);

            _arrowController = new ArrowController();

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

            }
        }
    }
}
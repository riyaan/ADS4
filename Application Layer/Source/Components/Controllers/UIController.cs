using Entities;
using MovementControl;
using SharedEvents;
using System;

namespace Controllers
{
    public class UIController
    {
        // Handling the arrow coordinate change
        public event EventHandler<ArrowChangedEventArgs> ArrowChanged;
        protected virtual void OnArrowChanged(ArrowChangedEventArgs e)
        {
            if (ArrowChanged != null)
                ArrowChanged(this, e);
        }

        // Handles the Arrow direction changed.
        public event EventHandler<ArrowDirectionChangedEventArgs> ArrowDirectionChanged;
        protected virtual void OnArrowDirectionChanged(ArrowDirectionChangedEventArgs e)
        {
            if (ArrowDirectionChanged != null)
                ArrowDirectionChanged(this, e);
        }


        private MazeController _mazeController;
        private MCLController _mclController;
        private ArrowController _arrowController;

        private ArrowDirectionChangedEventArgs _adcea;

        public UIController()
        {
        }

        void _arrowController_ArrowChanged(object sender, ArrowChangedEventArgs e)
        {            
            // Pass the event on to the calling party
            OnArrowChanged(e);
        }

        public Maze GenerateNewMaze(int rows, int columns)
        {
            // UI Controller interacts with the Maze Controller
            _mazeController = new MazeController(rows, columns);

            _arrowController = new ArrowController(_mazeController.Maze.Rows, _mazeController.Maze.Columns);

            _arrowController.ArrowChanged += _arrowController_ArrowChanged;

            _adcea = new ArrowDirectionChangedEventArgs();

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
                _adcea.Arrow = _arrowController.Arrow;

                switch (context.Direction)
                {
                    case "R":
                        // send an event back to the UI to change the arrow direction
                        OnArrowDirectionChanged(_adcea);
                        _arrowController.Right(context.Steps);                        
                        break;
                    case "L":
                        // send an event back to the UI to change the arrow direction
                        OnArrowDirectionChanged(_adcea);
                        _arrowController.Left(context.Steps);                        
                        break;
                    case "F":
                        // send an event back to the UI to change the arrow direction
                        OnArrowDirectionChanged(_adcea);
                        _arrowController.Forward(context.Steps);
                        break;
                }
                direction = context.Direction;
            }

            // return the coordinates of the arrow
            x = _arrowController.Arrow.X;
            y = _arrowController.Arrow.Y;            
        }
    }
}
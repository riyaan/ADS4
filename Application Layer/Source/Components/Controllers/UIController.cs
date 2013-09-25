using Entities;
using MovementControl;
using SharedEvents;
using System;
using System.Timers;

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

        private MazeController _mazeController;
        private MCLController _mclController;
        private ArrowController _arrowController;

        private Timer _timer;
        private static int _count = 0;

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

            _mclController = new MCLController();

            _timer = new Timer(3000);
            _timer.Elapsed += _timer_Elapsed;

            return _mazeController.Maze; // return the maze for display purposes
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ProcessCommand();
        }

        public void ParseCommand(string command)
        {
            // UI Controller interacts with the MCL Controller            
            _mclController.ParseCommand(command);
            _timer.Enabled = true;
            //// Execute each command
            //foreach (Context context in _mclController.Context)
            //{
            //    switch (context.Direction)
            //    {
            //        case "R":
            //            // send an event back to the UI to change the arrow direction
            //            _arrowController.Right(context.Steps);                        
            //            break;
            //        case "L":
            //            // send an event back to the UI to change the arrow direction
            //            _arrowController.Left(context.Steps);                        
            //            break;
            //        case "F":
            //            // send an event back to the UI to change the arrow direction
            //            _arrowController.Forward(context.Steps);
            //            break;
            //    }
            //}       
        }

        // Process each command group using a Timer
        private void ProcessCommand()
        {
            if (_count <= _mclController.Context.Count)
            {
                Context context = _mclController.Context[_count];
                switch (context.Direction)
                {
                    case "R":
                        // send an event back to the UI to change the arrow direction
                        _arrowController.Right(context.Steps);
                        break;
                    case "L":
                        // send an event back to the UI to change the arrow direction
                        _arrowController.Left(context.Steps);
                        break;
                    case "F":
                        // send an event back to the UI to change the arrow direction
                        _arrowController.Forward(context.Steps);
                        break;
                }
                _count++;
            }
            else
            {
                _count = 0;
                _timer.Enabled = false;
            }
        }
    }
}
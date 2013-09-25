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
            _arrowController.AnimationCompleted += _arrowController_AnimationCompleted;

            _mclController = new MCLController();

            //_timer = new Timer(6000);
            //_timer.Elapsed += _timer_Elapsed;

            return _mazeController.Maze; // return the maze for display purposes
        }

        void _arrowController_AnimationCompleted(object sender, EventArgs e)
        {
            ProcessCommand();
        }

        //void _timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Diagnostics.Logger.Instance.Log("Timer elapsed.");
        //    ProcessCommand();
        //}

        public void ParseCommand(string command)
        {
            Diagnostics.Logger.Instance.Log("Parsing the command: " + command);
            // UI Controller interacts with the MCL Controller            
            _mclController.ParseCommand(command);

            //Diagnostics.Logger.Instance.Log("Enabling the timer");
            //_timer.Enabled = true;
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

            ProcessCommand();
        }

        // Process each command group using a Timer
        private void ProcessCommand()
        {
            Diagnostics.Logger.Instance.Log("Processing command");
            Diagnostics.Logger.Instance.Log("Count = " + _count);
            Diagnostics.Logger.Instance.Log("Context count: " + _mclController.Context.Count);

            if (_count <= _mclController.Context.Count-1)
            {
                Diagnostics.Logger.Instance.Log("Count is less thant Context count");
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
                Diagnostics.Logger.Instance.Log("All contexts have been processed.");
                Diagnostics.Logger.Instance.Log("Resetting count");
                Diagnostics.Logger.Instance.Log("Disabling the timer.");
                _count = 0;
                _timer.Enabled = false;
            }
        }
    }
}
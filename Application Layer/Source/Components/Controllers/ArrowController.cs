using Entities;
using SharedEvents;
using System;
using System.Configuration;
using System.Timers;

namespace Controllers
{
    public class ArrowController
    {
        // Notify the UI Controller that the X and Y coordinates of the
        // Arrow has changed.
        public event EventHandler<ArrowChangedEventArgs> ArrowChanged;
        protected virtual void OnArrowChanged(ArrowChangedEventArgs e)
        {
            if (ArrowChanged != null)
                ArrowChanged(this, e);
        }

        // Notify the UI Controller that the current command has finished execution.
        // If this is a Composite command, the next command can be sent through.
        public event EventHandler AnimationCompleted;
        protected virtual void OnAnimationCompleted(EventArgs e)
        {
            if (AnimationCompleted != null)
                AnimationCompleted(this, e);
        }

        public ArrowContext Arrow { get; set; }

        private int _rows;
        private int _columns;
        private ArrowChangedEventArgs _acea;

        // utilize a timer that will update the arrow slowly.
        private Timer _timer;
        private string _direction;
        private int _steps;
        private static int _count = 0;

        public ArrowController(int rows, int columns)
        {
            Arrow = new ArrowContext(new ConcreteStateForward());
            Arrow.X = 0;
            Arrow.Y = 0;

            _rows = rows;
            _columns = columns;

            _acea = new ArrowChangedEventArgs();

            // TODO: Create a 'Common' configuration class for this.
            ConfigurationManager.RefreshSection("appSettings");
            int speed = Int32.Parse(ConfigurationManager.AppSettings["animationSpeed"]) * 1000;

            _timer = new Timer(speed); 
            _timer.Elapsed += _timer_Elapsed;
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Diagnostics.Logger.Instance.Log("Timer elapsed");
            AnimateArrow();
        }

        private void AnimateArrow()
        {
            switch (_direction)
            {
                case "F": // TODO: Get rid of 'magic values'. Create an enumeration.
                    if (_count < _steps)
                    {
                        if ((Arrow.Y + 1) <= _rows)
                        {
                            Arrow.Forward();
                            RaiseEvent();
                            _count++;
                        }
                    }
                    else
                        RaiseOnAnimationCompletedEvent();
                    break;
                case "R":
                    if (_count < _steps)
                    {
                        if ((Arrow.X - 1) >= 0)
                        {
                            Arrow.Right();
                            RaiseEvent();
                            _count++;
                        }
                    }
                    else
                        RaiseOnAnimationCompletedEvent();
                    break;
                case "L":
                    if (_count < _steps)
                    {
                        if ((Arrow.X + 1) <= _columns)
                        {
                            Arrow.Left();
                            RaiseEvent();
                            _count++;
                        }
                    }
                    else
                        RaiseOnAnimationCompletedEvent();
                    break;
            }
        }

        public void Forward(int steps)
        {
            Diagnostics.Logger.Instance.Log("Moving Forward");
            _timer.Enabled = true;
            _direction = "F";
            _steps = steps;
        }

        public void Right(int steps)
        {
            Diagnostics.Logger.Instance.Log("Moving Right");
            _timer.Enabled = true;
            _direction = "R";
            _steps = steps;
        }

        public void Left(int steps)
        {
            Diagnostics.Logger.Instance.Log("Moving Left");
            _timer.Enabled = true;
            _direction = "L";
            _steps = steps;
        }

        private void RaiseEvent()
        {
            _acea.Arrow = Arrow;
            OnArrowChanged(_acea);
        }

        private void RaiseOnAnimationCompletedEvent()
        {
            Diagnostics.Logger.Instance.Log("Animation completed");
            _timer.Enabled = false;
            _count = 0;
            OnAnimationCompleted(new EventArgs());
        }
    }
}

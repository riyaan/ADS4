using Entities;
using SharedEvents;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Controllers
{
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }

    public class ArrowController: Subject
    {
        public event EventHandler<ArrowChangedEventArgs> ArrowChanged;

        protected virtual void OnArrowChanged(ArrowChangedEventArgs e)
        {
            if (ArrowChanged != null)
                ArrowChanged(this, e);
        }

        private ArrowContext subjectState;

        public ArrowContext SubjectState
        {
          get { return subjectState; }
          set { subjectState = value; }
        }

        private ArrowContext arrow;

        public ArrowContext Arrow
        {
            get { return arrow; }
            set { arrow = value; }
        }

        private int _rows;
        private int _columns;
        private ArrowChangedEventArgs _acea;

        public ArrowController(int rows, int columns)
        {
            Arrow = new ArrowContext(new ConcreteStateForward());
            Arrow.X = 0;
            Arrow.Y = 0;

            _rows = rows;
            _columns = columns;

            _acea = new ArrowChangedEventArgs();
        }

        public void Forward(int steps)
        {
            for (int i = 0; i <= steps; i++)
            {                
                if ((Arrow.Y + 1) <= _rows)
                {
                    Arrow.Forward();                    
                    RaiseEvent();
                    //System.Threading.Thread.Sleep(3000);
                    //this.Notify();                    
                }
            }
        }

        private void RaiseEvent()
        {
            _acea.Arrow = Arrow;
            OnArrowChanged(_acea);
        }

        public void Right(int steps)
        {
            for (int i = 0; i <= steps; i++)
            {
                if ((Arrow.X - 1) >= 0)
                {
                    Arrow.Right();
                    RaiseEvent();
                    //System.Threading.Thread.Sleep(3000);
                    //_timer.Enabled = true;
                    //this.Notify();
                }
            }
        }

        public void Left(int steps)
        {
            for (int i = 0; i <= steps; i++)
            {
                if ((Arrow.X + 1) <= _columns)
                {
                    Arrow.Left();
                    RaiseEvent();
                    //System.Threading.Thread.Sleep(3000);
                    //_timer.Enabled = true;
                    //this.Notify();
                }
            }
        }
    }
}

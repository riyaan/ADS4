using Entities;
using SharedEvents;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Controllers
{
    public class ArrowController
    {
        public event EventHandler<ArrowChangedEventArgs> ArrowChanged;

        protected virtual void OnArrowChanged(ArrowChangedEventArgs e)
        {
            if (ArrowChanged != null)
                ArrowChanged(this, e);
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
            for (int i = 0; i < steps; i++)
            {                
                if ((Arrow.Y + 1) <= _rows)
                {
                    Arrow.Forward();                    
                    RaiseEvent();              
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
            for (int i = 0; i < steps; i++)
            {
                if ((Arrow.X - 1) >= 0)
                {
                    Arrow.Right();
                    RaiseEvent();
                }
            }
        }

        public void Left(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if ((Arrow.X + 1) <= _columns)
                {
                    Arrow.Left();
                    RaiseEvent();
                }
            }
        }
    }
}

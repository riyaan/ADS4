using System;

namespace Entities
{
    public abstract class ArrowState
    {
        public abstract void Forward(ArrowContext context);
        public abstract void Right(ArrowContext context);
        public abstract void Left(ArrowContext context);
    }

    public class ArrowContext
    {
        private ArrowState _currentState;

        public ArrowState CurrentState 
        {
            get { return _currentState; }            
            set { _currentState = value; } 
        }

        public ArrowContext(ArrowState arrowState)
        {
            this.CurrentState = arrowState;

            this.X = 0;
            this.Y = 0;
        }

        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public void Forward() { this.CurrentState.Forward(this); }

        public void Left() { this.CurrentState.Left(this); }

        public void Right() { this.CurrentState.Right(this); }
    }    

    public class ConcreteStateForward : ArrowState
    {
        public ConcreteStateForward() { }

        public override void Forward(ArrowContext context)
        {
            context.Y++;
        }

        public override void Left(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateLeft();
            context.X++;
        }

        public override void Right(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateRight();
            context.X--;
        }
    }

    public class ConcreteStateLeft : ArrowState
    {
        public ConcreteStateLeft() { }

        public override void Forward(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateForward();
            context.Y++;
        }

        public override void Left(ArrowContext context)
        {
            context.X++;
        }

        public override void Right(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateRight();
            context.X--;
        }

    }

    public class ConcreteStateRight : ArrowState
    {
        public ConcreteStateRight() { }

        public override void Forward(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateForward();
            context.Y++;
        }

        public override void Left(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateLeft();
            context.X++;
        }

        public override void Right(ArrowContext context)
        {
            context.X--;
        }
    }
}
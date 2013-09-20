﻿using System;

namespace Entities
{
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
        public void Downward() { this.CurrentState.Downward(this); }
        public void Left() { this.CurrentState.Left(this); }
        public void Right() { this.CurrentState.Right(this); }
    }

    public abstract class ArrowState
    {
        public abstract void Forward(ArrowContext context);
        public abstract void Downward(ArrowContext context);
        public abstract void Right(ArrowContext context);
        public abstract void Left(ArrowContext context);
    }

    public class ConcreteStateForward : ArrowState
    {
        public ConcreteStateForward()
        {
            Console.WriteLine("Forward FACING");
        }

        public override void Forward(ArrowContext context)
        {
            Console.WriteLine("NO EFFECT. MOVING.");
        }

        public override void Downward(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateDownward();
        }

        public override void Left(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateLeft();
        }

        public override void Right(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateRight();
        }
    }

    public class ConcreteStateDownward : ArrowState
    {
        public ConcreteStateDownward()
        {            
            Console.WriteLine("Downward FACING");
        }

        public override void Forward(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateForward();            
        }

        public override void Downward(ArrowContext context)
        {
            Console.WriteLine("No effect. Moving");
        }

        public override void Left(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateLeft();
        }

        public override void Right(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateRight();
        }
    }

    public class ConcreteStateLeft : ArrowState
    {
        public ConcreteStateLeft()
        {
            Console.WriteLine("Left FACING");
        }

        public override void Forward(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateForward();
        }

        public override void Downward(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateDownward();
        }

        public override void Left(ArrowContext context)
        {
            Console.WriteLine("No effect. Moving");
        }

        public override void Right(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateRight();
        }

    }

    public class ConcreteStateRight : ArrowState
    {
        public ConcreteStateRight()
        {
            Console.WriteLine("Downward FACING");
        }

        public override void Forward(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateForward();
        }

        public override void Downward(ArrowContext context)
        {
            Console.WriteLine("No effect. Moving");
        }

        public override void Left(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateLeft();
        }

        public override void Right(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateRight();
        }
    }
}
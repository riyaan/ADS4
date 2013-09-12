using System;

namespace DS_S2_A2
{
    /// <summary>
    /// 
    /// </summary>
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
        }

        public void MoveNorth() { this.CurrentState.MoveNorth(this); }
        public void MoveSouth() { this.CurrentState.MoveSouth(this); }
        public void MoveWest() { this.CurrentState.MoveWest(this); }
        public void MoveEast() { this.CurrentState.MoveEast(this); }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class ArrowState
    {
        public abstract void MoveNorth(ArrowContext context);
        public abstract void MoveSouth(ArrowContext context);
        public abstract void MoveWest(ArrowContext context);
        public abstract void MoveEast(ArrowContext context);
    }

    public class ConcreteStateNorth : ArrowState
    {
        public ConcreteStateNorth()
        {
            Console.WriteLine("NORTH FACING");
        }

        public override void MoveNorth(ArrowContext context)
        {
            Console.WriteLine("NO EFFECT. MOVING.");
        }

        public override void MoveSouth(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateSouth();
        }

        public override void MoveWest(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateWest();
        }

        public override void MoveEast(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateEast();
        }
    }

    public class ConcreteStateSouth : ArrowState
    {
        public ConcreteStateSouth()
        {            
            Console.WriteLine("SOUTH FACING");
        }

        public override void MoveNorth(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateNorth();            
        }

        public override void MoveSouth(ArrowContext context)
        {
            Console.WriteLine("No effect. Moving");
        }

        public override void MoveWest(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateWest();
        }

        public override void MoveEast(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateEast();
        }
    }

    public class ConcreteStateWest : ArrowState
    {
        public ConcreteStateWest()
        {
            Console.WriteLine("WEST FACING");
        }

        public override void MoveNorth(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateNorth();
        }

        public override void MoveSouth(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateSouth();
        }

        public override void MoveWest(ArrowContext context)
        {
            Console.WriteLine("No effect. Moving");
        }

        public override void MoveEast(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateEast();
        }

    }

    public class ConcreteStateEast : ArrowState
    {
        public ConcreteStateEast()
        {
            Console.WriteLine("SOUTH FACING");
        }

        public override void MoveNorth(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateNorth();
        }

        public override void MoveSouth(ArrowContext context)
        {
            Console.WriteLine("No effect. Moving");
        }

        public override void MoveWest(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateWest();
        }

        public override void MoveEast(ArrowContext context)
        {
            context.CurrentState = new ConcreteStateEast();
        }
    }
}
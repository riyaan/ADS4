using System;

namespace Entities
{
    public enum CELLSTATE { OPEN, BLOCKED };

    public class CellContext
    {
        #region Private Members

        private CELLSTATE _cellState;

        public CELLSTATE CellState
        {
            get { return _cellState; }
            set { _cellState = value; }
        }

        private CellState _currentState;

        public CellState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        private int xCoordinate;

        public int XCoordinate
        {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }

        private int yCoordinate;

        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        #endregion Private Members

        #region Constructor 

        public CellContext(CellState state)
        {
            this.CurrentState = state;
        }

        #endregion Constructor

        public void MoveOpen() 
        { 
            this.CurrentState.MoveOpen(this);
            this.CellState = CELLSTATE.OPEN;
        }

        public void MoveBlocked() 
        { 
            this.CurrentState.MoveBlocked(this);
            this.CellState = CELLSTATE.BLOCKED;
        }

        /*
         * Business Logic methods
         * */
        #region Business Logic Methods

        public bool Occupy()
        {
            bool CanOccupy = false;

            switch (this.CellState)
            {
                case CELLSTATE.OPEN:
                    this.CurrentState = new ConcreteStateBlocked();
                    this.CellState = CELLSTATE.BLOCKED;                    
                    CanOccupy = true;
                    break;
                case CELLSTATE.BLOCKED:
                    this.CurrentState.MoveBlocked(this);
                    CanOccupy = false;
                    break;
            }

            return CanOccupy;
        }

        public bool UnOccupy()
        {
            bool UnOccupied = false;

            switch (this.CellState)
            {
                case CELLSTATE.OPEN:
                    this.CurrentState.MoveOpen(this);
                    UnOccupied = true;
                    break;
                case CELLSTATE.BLOCKED:
                    this.CurrentState = new ConcreteStateOpen();
                    this.CellState = CELLSTATE.OPEN;
                    UnOccupied = true;
                    break;
            }

            return UnOccupied;
        }

        #endregion Business Logic Methods

    }

    public abstract class CellState
    {
        public abstract void MoveOpen(CellContext context);
        public abstract void MoveBlocked(CellContext context);

        public abstract override string ToString();
    }

    #region The concrete implementations

    public class ConcreteStateOpen : CellState
    {
        public ConcreteStateOpen()
        {
            Console.WriteLine("Cell is now open.");
        }

        public override void MoveOpen(CellContext context)
        {
            Console.WriteLine("Moved to open cell.");
        }

        public override void MoveBlocked(CellContext context)
        {
            context.CurrentState = new ConcreteStateBlocked();
            context.CellState = CELLSTATE.BLOCKED;
            Console.WriteLine("Cell is now occupied.");
        }

        public override string ToString()
        {
            return "Open State";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConcreteStateBlocked : CellState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteStateBlocked"/> class.
        /// </summary>
        public ConcreteStateBlocked()
        {
            Console.WriteLine("Cell is now blocked.");            
        }

        public override void MoveOpen(CellContext context)
        {
            Console.WriteLine("Cannot move, cell is blocked.");
        }

        public override void MoveBlocked(CellContext context)
        {
            Console.WriteLine("Cannot move, cell is already blocked.");
        }

        public override string ToString()
        {
            return "Blocked State";
        }
    }

    #endregion The concrete implementations
}

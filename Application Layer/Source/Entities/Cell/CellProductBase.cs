using System;
using System.Collections.Generic;

namespace Entities.Cell
{
    #region ENUMS

    public enum CELL_TYPE { CLOSED, OPEN, START, END, OCCUPIED }
    public enum CELL_COLOUR { BLACK, WHITE, RED, GREEN, GREY }

    #endregion ENUMS

    public abstract class CellProductBase
    {
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

        List<CellProductBase> adjacents;

        public List<CellProductBase> Adjacents
        {
            get { return adjacents; }
            set { adjacents = value; }
        }

        public CELL_COLOUR CellColour { get; private set; }

        protected CellProductBase(CELL_COLOUR cellColour)
        {
            this.CellColour = cellColour;
        }

        public abstract void Display();
    }

    public class OpenCell : CellProductBase
    {
        public OpenCell(CELL_COLOUR colour) : base(colour) { }

        public override void Display()
        {
            Console.WriteLine(String.Format("Cell colour: {0}", this.CellColour.ToString()));
        }
    }

    public class ClosedCell : CellProductBase
    {
        public ClosedCell(CELL_COLOUR colour) : base(colour) { }

        public override void Display()
        {
            Console.WriteLine(String.Format("Cell colour: {0}", this.CellColour.ToString()));
        }
    }

    public class StartCell : CellProductBase
    {
        public StartCell(CELL_COLOUR colour) : base(colour) { }

        public override void Display()
        {
            Console.WriteLine(String.Format("Cell colour: {0}", this.CellColour.ToString()));
        }
    }

    public class EndCell : CellProductBase
    {
        public EndCell(CELL_COLOUR colour) : base(colour) { }

        public override void Display()
        {
            Console.WriteLine(String.Format("Cell colour: {0}", this.CellColour.ToString()));
        }
    }

    public class OccupiedCell : CellProductBase
    {
        public OccupiedCell(CELL_COLOUR colour) : base(colour) { }

        public override void Display()
        {
            Console.WriteLine(String.Format("Cell colour: {0}", this.CellColour.ToString()));
        }
    }
}

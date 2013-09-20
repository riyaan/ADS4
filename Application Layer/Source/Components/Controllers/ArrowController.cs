using Entities;

namespace Controllers
{
    public class ArrowController
    {
        private ArrowContext arrow;

        public ArrowContext Arrow
        {
            get { return arrow; }
            set { arrow = value; }
        }

        private int _rows;
        private int _columns;

        public ArrowController(int rows, int columns)
        {
            Arrow = new ArrowContext(new ConcreteStateForward());
            Arrow.X = 0;
            Arrow.Y = 0;

            _rows = rows;
            _columns = columns;
        }

        public void Forward(int steps)
        {
            for (int i = 0; i <= steps; i++)
            {
                if((Arrow.Y + 1) <= _rows)
                    Arrow.Forward();
            }
        }

        public void Right(int steps)
        {
            for (int i = 0; i <= steps; i++)
            {
                if ((Arrow.X + 1) <= _columns)
                    Arrow.Right();
            }
        }

        public void Left(int steps)
        {
            for (int i = 0; i <= steps; i++)
            {
                if ((Arrow.X - 1) >= 0)
                    Arrow.Left();
            }
        }
    }
}

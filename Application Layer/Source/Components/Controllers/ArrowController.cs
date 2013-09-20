﻿using Entities;

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

        public ArrowController()
        {
            Arrow = new ArrowContext(new ConcreteStateForward());
            Arrow.X = 0;
            Arrow.Y = 0;
        }

        public void Forward(int steps)
        {
            for (int i = 0; i < steps; i++)
                Arrow.Forward();
        }

        public void Right(int steps)
        {
            for (int i = 0; i < steps; i++)
                Arrow.Right();
        }

        public void Left(int steps)
        {
            for(int i=0; i<steps; i++)
                Arrow.Left();
        }
    }
}
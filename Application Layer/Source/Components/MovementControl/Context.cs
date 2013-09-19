using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementControl
{
    public class Context
    {
        public string Direction;
        public int Steps;

        public Context(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
    }
}

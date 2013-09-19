using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementControl
{
    public class MclCommand : ExpressionBase
    {
        string Command;

        public MclCommand(string command)
        {
            Command = command;            
        }

        // Parse this command into a Direction and number of steps
        public override Context Interpret()
        {
            // e.g R5
            string direction = Command[0].ToString();            
            int steps = Int32.Parse(Command[1].ToString());

            return new Context(direction, steps);
        }

        public override string ToString()
        {
            return Command;
        }
    }
}

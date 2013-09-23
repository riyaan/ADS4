using System;

namespace MovementControl
{
    public class MclCommand : ExpressionBase
    {
        string Command;

        // The command will be in the form: Dn
        // D: Direction
        // n: Number of steps
        public MclCommand(string command)
        {
            Command = command;            
        }

        // Parse this command into a Direction and number of steps
        public override Context Interpret()
        {
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
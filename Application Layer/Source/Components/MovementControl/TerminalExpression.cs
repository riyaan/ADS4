using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementControl
{
    public class TerminalExpression : ExpressionBase
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine(String.Format("Terminal for {0}", context.Command));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

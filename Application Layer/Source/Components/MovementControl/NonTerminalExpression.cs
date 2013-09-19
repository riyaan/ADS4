using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementControl
{
    public class NonTerminalExpression : ExpressionBase
    {
        public ExpressionBase exp1 { get; set; }
        public ExpressionBase exp2 { get; set; }

        public override void Interpret(Context context)
        {
            Console.WriteLine(String.Format("Non-Terminal for {0}", context.Command));
            exp1.Interpret(context);
            exp2.Interpret(context);
        }
    }
}

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

        public override Context Interpret()
        {
            throw new NotImplementedException();
        }
    }
}

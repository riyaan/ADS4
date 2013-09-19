using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementControl
{
    public abstract class ExpressionBase
    {
        public abstract void Interpret(Context context);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovementControl
{
    public class Parser
    {
        /**http://derekslager.com/blog/posts/2007/09/a-better-dotnet-regular-expression-tester.ashx
         * */
        const string PATTERN = @"(F[1-9])|(R[1-9])|(L[1-9])";

        public ExpressionBase Parse(string mcl)
        {
            TerminalExpression te = null;

            Match match = Regex.Match(mcl, PATTERN);
            if (match.Success)
            {
                GroupCollection gc = match.Groups;
                te = new TerminalExpression();
            }

            return te;
        }
    }
}

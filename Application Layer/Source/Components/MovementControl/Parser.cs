using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MovementControl
{
    public class Parser
    {
        /**http://derekslager.com/blog/posts/2007/09/a-better-dotnet-regular-expression-tester.ashx
         * */
        const string PATTERN = @"(F[1-9])|(R[1-9])|(L[1-9])";

        public List<Context> Parse(string mcl)
        {
            List<Context> commands = new List<Context>();

            MatchCollection matchCollection = Regex.Matches(mcl, PATTERN);
            foreach (Match match in matchCollection)
            {
                foreach (Capture c in match.Captures)
                {
                    MclCommand mclCommand = new MclCommand(c.Value);
                    commands.Add(mclCommand.Interpret());
                }
            }

            return commands;       
        }
    }
}

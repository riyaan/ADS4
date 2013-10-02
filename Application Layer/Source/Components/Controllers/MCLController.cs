using MovementControl;
using System.Collections.Generic;

namespace Controllers
{
    public class MCLController
    {        
        public List<Context> Context { get; set; }

        public void ParseCommand(string command)
        {
            Parser parser = new Parser();
            Context = parser.Parse(command);            
        }
    }
}

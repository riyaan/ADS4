using MovementControl;
using System.Collections.Generic;

namespace Controllers
{
    public class MCLController
    {
        private List<Context> context;

        public List<Context> Context
        {
            get { return context; }
            set { context = value; }
        }

        public MCLController()
        {
        }

        public void ParseCommand(string command)
        {
            Parser parser = new Parser();
            Context = parser.Parse(command);            
        }
    }
}

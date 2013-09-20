using MovementControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace MazeNavigatorUI
{
    public class MazeLayoutPanel: TableLayoutPanel
    {
        public MazeLayoutPanel()
        {
            this.DoubleBuffered = true;
        }

        public MazeLayoutPanel(IContainer container)
        {
            container.Add(this);
            this.DoubleBuffered = true;
        }
    }
}

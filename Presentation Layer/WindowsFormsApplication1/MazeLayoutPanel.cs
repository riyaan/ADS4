using System.ComponentModel;
using System.Windows.Forms;

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

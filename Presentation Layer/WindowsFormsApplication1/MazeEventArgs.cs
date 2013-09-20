using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeNavigatorUI
{
    public class MazeEventArgs : EventArgs
    {
        public Maze Maze { get; set; }        
    }
}

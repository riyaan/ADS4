using Entities;
using System;

namespace SharedEvents
{
    public class ArrowChangedEventArgs : EventArgs
    {
        public ArrowContext Arrow { get; set; }
    }
}

using Entities;
using System;

namespace SharedEvents
{
    public class ArrowChangedEventArgs : EventArgs
    {
        public ArrowContext Arrow { get; set; }
    }

    public class ArrowDirectionChangedEventArgs : EventArgs
    {
        public ArrowContext Arrow { get; set; }
    }
}

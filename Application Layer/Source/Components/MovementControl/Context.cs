
namespace MovementControl
{
    public class Context
    {
        public string Direction { get; set; }
        public int Steps { get; set; }

        public Context(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
    }
}

namespace MovementControl
{
    public class Context
    {
        public string Direction;
        public int Steps;

        public Context(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
    }
}
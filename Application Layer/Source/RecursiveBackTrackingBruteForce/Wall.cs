
namespace RecursiveBackTrackingBruteForce
{
    public enum WallState { UP, DOWN }
    public enum WallDirection { NORTH, SOUTH, WEST, EAST }    

    public class Wall
    {
        public Wall(WallDirection wallDirection, WallState wallState)
        {
            Direction = wallDirection;
            State = wallState;
        }

        private WallState state;

        public WallState State
        {
          get { return state; }
          set { state = value; }
        }

        private WallDirection direction;

        public WallDirection Direction
        {
          get { return direction; }
          set { direction = value; }
        }
    }
    
}
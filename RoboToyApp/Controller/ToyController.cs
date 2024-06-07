namespace RoboToyApp.Controller
{
    /// <summary>
    /// Enum to store all valid directions - NORTH, EAST, SOUTH, WEST
    /// </summary>
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class ToyController : IToyController
    {
        private int _x;
        private int _y;
        private Direction _facing;
        private bool _isPlaced;

        public ToyController()
        {
            _isPlaced = false;
        }

        /// <summary>
        /// Places the robot toy at (x,y) coordinates facing the direction 'facing'
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        /// <param name="facing">Current Direction</param>
        public void Place(int x, int y, string facing)
        {
            if (IsValidPosition(x, y) && IsValidDirection(facing))
            {
                _x = x;
                _y = y;
                _facing = Enum.Parse<Direction>(facing);
                _isPlaced = true;
            }
            else
            {
                Console.WriteLine("Robot not placed, please check position (X,Y) facing direction F (NORTH, SOUTH, EAST, or WEST).");
            }
        }

        /// <summary>
        /// Move the robot one space in the direction it is facing without falling
        /// </summary>
        public void Move()
        {
            if (!_isPlaced)
            {
                return;
            }

            switch (_facing)
            {
                case Direction.NORTH:
                    if (_y < 4)
                    {
                        _y++;
                    }
                    break;
                case Direction.EAST:
                    if (_x < 4)
                    {
                        _x++;
                    }
                    break;
                case Direction.SOUTH:
                    if (_y > 0)
                    {
                        _y--;
                    }
                    break;
                case Direction.WEST:
                    if (_x > 0)
                    {
                        _x--;
                    }
                    break;
            }
        }

        /// <summary>
        /// Rotates the robot 90 degrees towards left of current direction
        /// </summary>
        public void Left()
        {
            if (!_isPlaced)
            {
                return;
            }

            int intDirection = (int)_facing + 3;
            int newDirection = intDirection % Enum.GetValues(typeof(Direction)).Length;
            _facing = (Direction)newDirection;
        }

        /// <summary>
        /// Rotates the robot 90 degrees towards right of current direction
        /// </summary>
        public void Right()
        {
            if (!_isPlaced)
            {
                return;
            }
            int intDirection = (int)_facing + 1;
            int newDirection = intDirection % Enum.GetValues(typeof(Direction)).Length;
            _facing = (Direction)newDirection;
        }

        /// <summary>
        /// Report the current coordinates and direction to the console
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            if (!_isPlaced)
            {
                return "Robot is not placed on the table.";
            }

            return $"{_x},{_y},{_facing}";
        }

        /// <summary>
        /// Checks the validity of the passed x and y coordinates
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinates</param>
        /// <returns></returns>
        private bool IsValidPosition(int x, int y)
        {
            // Robot should not fall off the 5x5 board
            return x >= 0 && x <= 4 && y >= 0 && y <= 4;
        }

        /// <summary>
        /// Checks the validity of the passed direction string
        /// </summary>
        /// <param name="direction">Direction Robot is facing</param>
        /// <returns></returns>
        private bool IsValidDirection(string direction)
        {
            var validDirections = Enum.GetNames<Direction>();
            Direction facing;

            // Check if valid direction is provided in the input
            if (validDirections.Contains(direction) && Enum.TryParse<Direction>(direction, out facing))
            {
                return true;
            }
            return false;
        }
    }
}

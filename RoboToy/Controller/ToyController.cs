using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboToy.Controller
{
    public class ToyController
    {
        private int _x;
        private int _y;
        private Direction _facing;
        private bool _isPlaced;

        public enum Direction
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        public ToyController()
        {
            _isPlaced = false;
        }

        public void Place(int x, int y, Direction facing)
        {
            if (IsValidPosition(x, y))
            {
                _x = x;
                _y = y;
                _facing = facing;
                _isPlaced = true;
            }
        }

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

        public string Report()
        {
            if (!_isPlaced)
            {
                return "Robot is not placed on the table.";
            }

            return $"{_x},{_y},{_facing}";
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x <= 4 && y >= 0 && y <= 4;
        }
    }
}

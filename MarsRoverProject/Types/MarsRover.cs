using System;
using MarsRoverProject.Contract;

namespace MarsRoverProject.Types
{
    public class MarsRover : IMarsRover
    {
        private readonly IGrid _grid;

        private int _x, _y;
        private char _dir;
        public MarsRover(int x, int y, char dir, IGrid grid)
        {
            _x = x;
            _y = y;
            _dir = dir;
            _grid = grid;

            SeedToGrid();
        }

        private void SeedToGrid()
        {
            if (!_grid.TryPlot(_x, _y))
            {
                throw new Exception("Grid position already taken");
            }
        }

        public void MoveOne(char dir)
        {
            switch (dir)
            {
                case 'M': MoveRover(); return;
                case 'L': OrientLeft(); return;
                case 'R': OrientRight(); return;
            }
        }

        public void MoveMany(string dir)
        {
            foreach (var item in dir)
            {
                MoveOne(item);
            }
        }

        public string GetPosition() => $"{_x} {_y} {_dir}";

        private void MoveRover()
        {
            var newX = _x;
            var newY = _y;
            switch (_dir)
            {
                case 'W': newX--; break;
                case 'E': newX++; break;
                case 'N': newY++; break;
                case 'S': newY--; break;
            }

            if (_grid.TryPlot(newX, newY))
            {
                _grid.Clear(_x, _y);

                _x = newX;
                _y = newY;
            }
            else
            {
                // If we can't plot the rover here, we can't move it either so ignore the command for now.
            }
        }

        private void OrientLeft()
        {
            switch (_dir)
            {
                case 'N': _dir = 'W'; return;
                case 'W': _dir = 'S'; return;
                case 'S': _dir = 'E'; return;
                case 'E': _dir = 'N'; return;
            }
        }

        private void OrientRight()
        {
            switch (_dir)
            {
                case 'N': _dir = 'E'; return;
                case 'W': _dir = 'N'; return;
                case 'S': _dir = 'W'; return;
                case 'E': _dir = 'S'; return;
            }
        }
    }
}

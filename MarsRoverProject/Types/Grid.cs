
using MarsRoverProject.Contract;
using System;

namespace MarsRoverProject.Types
{
    /// <summary>
    /// Must be registered as shared instance
    /// NB.: The Grid cannot think for itself, it only knows which of its blocks are occupied at any given time.
    /// </summary>
    public class Grid : IGrid
    {
        private readonly bool[,] _grid;
        private readonly int _width;
        private readonly int _height;

        /// <summary>
        /// The width and height will be injected by a configuration provider in due course.
        /// </summary>
        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _grid = new bool[width + 1, height + 1]; // Judging from the test output the grid is zero-based (plus 1)
        }

        public bool TryPlot(int x, int y)
        {
            if (CanPlot(x, y))
            {
                Plot(x, y);
                return true;
            }

            return false;
        }

        public void Clear(int x, int y) => _grid[x, y] = false;

        public bool CanPlot(int x, int y)
        {          
            if (x > _width || x < 0) return false;

            if (y > _height || y < 0) return false;

            if (_grid[x, y]) return false;

            return true;
        }

        private void Plot(int x, int y) => _grid[x, y] = true;
    }
}

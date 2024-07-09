
namespace MarsRoverProject.Contract
{
    public interface IGrid
    {
        bool TryPlot(int x, int y);
        public void Clear(int x, int y);
        public bool CanPlot(int x, int y);
    }
}
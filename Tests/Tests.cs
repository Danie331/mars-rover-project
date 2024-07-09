using Autofac;
using Autofac.Builder;
using MarsRoverProject.Contract;
using MarsRoverProject.Types;

namespace Tests
{
    public class Tests
    {
        private IContainer _container;
        [SetUp]
        public void Setup()
        {
            var containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<MarsRover>().As<IMarsRover>();
            containerBuilder.RegisterType<Grid>().As<IGrid>().SingleInstance(); // shared grid 

            _container = containerBuilder.Build(ContainerBuildOptions.IgnoreStartableComponents);
        }

        [Test]
        public void Test1()
        {
            // Test 2 rovers according to: https://code.google.com/archive/p/marsrovertechchallenge/

            var myGrid = new Grid(5, 5); // Eventually inject this as a shared instance.

            var rover1 = new MarsRover(1, 2, 'N', myGrid);
            rover1.MoveMany("LMLMLMLMM");

            var rover2 = new MarsRover(3, 3, 'E', myGrid);
            rover2.MoveMany("MMRMMRMRRM");

            Assert.That(rover1.GetPosition(), Is.EqualTo("1 3 N"));
            Assert.That(rover2.GetPosition(), Is.EqualTo("5 1 E"));

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            // This test will check that rovers are created in a valid position on the grid
            Assert.Fail();
        }

        [Test]
        public void Test3()
        {
            // This test will cater for plotting multiple rovers on the grid,
            // ensuring each has its own x,y without overlaps.
            Assert.Fail();
        }

        [Test]
        public void Test4()
        {
            // This test will cater for collision detection between rovers when compound paths are used
            Assert.Fail();
        }
    }
}
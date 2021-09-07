using System;
using MathSpectre;
using Xunit;

namespace MathSpectreTests
{
    public class CubeTests
    {
        [Fact]
        public void CubeSizeTest()
        {
            var dimension = 1;
            var cube = new n_Cube(dimension);
            Assert.Equal(dimension + 1, cube.n_cube.Length);
            dimension++;
            cube = new n_Cube(dimension);
            Assert.Equal(dimension + 1, cube.n_cube.Length);
            dimension++;
            cube = new n_Cube(dimension);
            Assert.Equal(dimension + 1, cube.n_cube.Length);
            dimension++;
            cube = new n_Cube(dimension);
            Assert.Equal(dimension + 1, cube.n_cube.Length);
            dimension++;
            cube = new n_Cube(dimension);
            Assert.Equal(dimension + 1, cube.n_cube.Length);
        }
        [Fact]
        public void MNodesCountTest()
        {
            var dimension = 1;
            var cube = new n_Cube(dimension);
            Assert.Equal(Math.Pow(2, dimension), cube.MNodes.Count);
            dimension++;
            cube = new n_Cube(dimension);
            Assert.Equal(Math.Pow(2, dimension), cube.MNodes.Count);
            dimension++;
            cube = new n_Cube(dimension);
            Assert.Equal(Math.Pow(2, dimension), cube.MNodes.Count);
            dimension++;
            cube = new n_Cube(dimension);
            Assert.Equal(Math.Pow(2, dimension), cube.MNodes.Count);
        }
    }
}
﻿using System;
 using MathSpectre;
 using Xunit;

namespace MathSpectreTests
{
    public class AlgoritmTests
    {

        [Fact]
        public void XorTest()
        {
            var firstVector = new[] {0, 0, 1, 1};
            var secondVector = new[] {1, 0, 0, 1};
            var xorVector = Algoritm.Xor(firstVector,secondVector);
            Assert.Equal(new[] {1, 0, 1, 0}, xorVector);
            firstVector = new[] {0, 1, 1, 1};
            secondVector = new[] {1, 0, 1, 1};
            xorVector = Algoritm.Xor(firstVector,secondVector);
            Assert.Equal(new[] {1, 1, 0, 0}, xorVector);
        }

        [Fact]
        public void ComputeSpectreTest()
        {
            var spectre = Algoritm.ComputeSpectre(new n_Cube(1));
            Assert.Equal(new[] {0, 1}, spectre);
            spectre = Algoritm.ComputeSpectre(new n_Cube(2));
            Assert.Equal(new[] {0, 1, 2}, spectre);
            spectre = Algoritm.ComputeSpectre(new n_Cube(3));
            Assert.Equal(new[] {0, 1, 2, 3}, spectre);
        }

        [Fact]
        public void FindMaxSpectreTest()
        {
            var func = "11111111";
            var cube = new n_Cube((int) Math.Log(func.Length, 2));
            cube.SetMarks(func);
            Assert.Equal("0, 0, 0, 0" ,Algoritm.Solve(cube));
            func = "1111111100000000";
            cube = new n_Cube((int) Math.Log(func.Length, 2));
            cube.SetMarks(func);
            Assert.Equal("0, 1, 0, 0, 0" ,Algoritm.Solve(cube));
            func = "10110110110110110101011011011010";
            cube = new n_Cube((int) Math.Log(func.Length, 2));
            cube.SetMarks(func);
            Assert.Equal("0, 1, 2, 1, 1, 0" ,Algoritm.Solve(cube));
            func = "1011011011010110110110110110101011011011010110110101011011011010";
            cube = new n_Cube((int) Math.Log(func.Length, 2));
            cube.SetMarks(func);
            Assert.Equal("0, 1, 2, 1, 1, 1, 0" ,Algoritm.Solve(cube));
            func = "10110110110101101101101101101101101011011011011011010101101101101011011010101101101101010110101011011011010110110101011011011010";
            cube = new n_Cube((int) Math.Log(func.Length, 2));
            cube.SetMarks(func);
            Assert.Equal("0, 1, 2, 2, 1, 1, 0, 0" ,Algoritm.Solve(cube));
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;

namespace MathSpectre
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            var lines = File.ReadAllLines("in.txt");
            stopWatch.Start();
            var cube = new n_Cube((int) Math.Log(lines[0].Length, 2));
            cube.SetMarks(lines[0]);
            Console.WriteLine(Algoritm.Solve(cube));
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
            Console.WriteLine("Время выполнения:\n" + elapsedTime);
        }
    }
}
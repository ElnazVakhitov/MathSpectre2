using System;
using System.Collections.Generic;
using System.Linq;

namespace MathSpectre
{
    public static class Algoritm
    {
        public static string Solve(n_Cube cube)
        {
            var xorNodes = new int[cube.startNodes.Length][][];
            for (var i = 0; i < cube.startNodes.Length; i++)
            {
                xorNodes[i] = cube.startNodes
                    .Select(x => x.vector)
                    .Select(x => Xor(cube.startNodes[i].vector, x))
                    .ToArray();
            }
            var spectres = new int[xorNodes.Length][];
            for (var i = 0; i < xorNodes.Length; i++)
            {
                RepointCube(xorNodes[i], cube);
                spectres[i] = ComputeSpectre(cube);
            }
            return string.Join(", ", computeMaxSpectre(spectres, cube.n_cube.Length));
        }

        public static int[] Xor(IEnumerable<int> xorVector, IEnumerable<int> vector) => xorVector.Zip(vector, (x, y) => x ^ y).ToArray();


        static void RepointCube(IEnumerable<int[]> vectors, n_Cube cube) => cube.Repoint(vectors);


        public static int[] ComputeSpectre(n_Cube cube)
        {
            var spectre = new int[cube.n_cube.Length];
            for (var i = 1; i < cube.n_cube.Length; i++)
            {
                for (var j = 0; j < cube.n_cube[i].Length; j++)
                {
                    var node = cube.n_cube[i][j];
                    var pmin = node.linked.Min(n => n.m);
                    node.p = pmin;
                    if (node.p < i - 1)
                        node.m = node.p;
                    else if (node.l)
                        node.m = i - 1;
                    else
                        node.m = i;
                    pmin = node.m < pmin ? node.m : pmin;
                    spectre[i] = spectre[i] < node.m ? node.m : spectre[i];
                }
            }
            return spectre;
        }

        static IEnumerable<int> computeMaxSpectre(int[][] spectres, int n)
        {
            return Enumerable.Range(0, n).Select(x => spectres.Max(y => y[x])).ToArray();
        }
    }
}

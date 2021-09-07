using System;
using System.Collections.Generic;
using System.Linq;

namespace MathSpectre
{
    public class n_Cube
    {
        public Dictionary<int, Node> MNodes;
        public readonly Node[][] n_cube;
        public readonly int n;
        public Node[] startNodes;

        public n_Cube(int n)
        {
            this.n = n;
            n_cube = new Node[n + 1][];
            SetMNodes();
            for (var i = 0; i < n + 1; i++) n_cube[i] = GetNodes(i);
        }

        private Node[] GetNodes(int unitNum)
        {
            var nodes = new List<Node>();
            foreach (var (_, node) in MNodes)
            {
                var currentUnitNum = node.vector.Sum();
                if (currentUnitNum != unitNum) continue;
                nodes.Add(node);
            }
            return nodes.ToArray();
        }

        private void SetMNodes()
        {
            MNodes = new Dictionary<int, Node>();
            var length = Convert.ToString((int) Math.Pow(2, n) - 1, 2).ToCharArray().Length;
            for (var i = 0; i < Math.Pow(2, n); i++)
            {
                var binaryCode = Convert.ToString(i, 2).ToCharArray().Select(x => x - '0').ToList();
                var zeroCount = length - binaryCode.Count;
                for (var j = 0; j < zeroCount; j++) binaryCode.Insert(0, 0);
                binaryCode.Reverse();
                var vector = binaryCode.ToArray();
                MNodes[FromVectorToInt(vector)] = new Node(vector) {linked = GetLinks(binaryCode)}; 
            }
        }
        
        public void SetMarks(string func)
        {
            var nodes = new List<Node>();
            for (var i = 0; i < func.Length; i++)
            {
                if (func[i] != '1') continue;
                MNodes[i].l = true;
                nodes.Add(MNodes[i]);
            }
            startNodes = nodes.ToArray();
        }

        private Node[] GetLinks(IList<int> currentVector)
        {
            var hashSet = new HashSet<Node>();
            for (var i = 0; i < currentVector.Count; i++)
            {
                if (currentVector[i] == 0) continue;
                currentVector[i] = 0;
                var index = FromVectorToInt(currentVector);
                var node = MNodes[index];
                if (hashSet.Contains(node)) currentVector[i] = 1;
                else
                {
                    hashSet.Add(node);
                    currentVector[i] = 1;
                }
            }

            return hashSet.ToArray();
        }
        
        public void Clear()
        {
            foreach (var n in MNodes.Values)
            {
                n.l = false;
                n.p = 0;
                n.m = 0;
            }
        }

        public void Repoint(IEnumerable<int[]> vectors)
        {
            Clear();
            foreach (var vector in vectors)
                MNodes[FromVectorToInt(vector)].l = true;
        }

        public static int FromVectorToInt(IEnumerable<int> vector)
        {
            return vector.Select((x, index) => x << index).Sum();
        }
    }
}

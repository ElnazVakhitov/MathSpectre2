namespace MathSpectre
{
    public class Node
    {
        public Node[] linked;
        public bool l;
        public int p;
        public int m;
        public int[] vector;

        public Node(int[] init)
        {
            vector = init;
        }
    }
}
namespace Sorting.Trees
{
    public class BinaryNode
    {
        public int value;
        public BinaryNode left;
        public BinaryNode right;

        public BinaryNode(int value)
        {
            this.value = value;
        }


        public static void Run()
        {
            var root = new BinaryNode(1);
            root.left = new BinaryNode(2);
            root.right = new BinaryNode(3);
            root.left.left = new BinaryNode(4);
            root.left.right = new BinaryNode(5);
            root.right.left = new BinaryNode(6);

            BinaryNode.Preorder(root);
        }

        public static void Preorder(BinaryNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.value + " ");
            Preorder(node.left);
            Preorder(node.right);
        }
    }
}
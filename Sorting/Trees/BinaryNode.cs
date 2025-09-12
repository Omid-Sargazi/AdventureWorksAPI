using System.Collections;

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

            // BinaryNode.Preorder(root);
            BinaryNode.Postorder(root);
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

        public static void Inorder(BinaryNode node)
        {
            if (node == null) return;
            Inorder(node.left);
            Console.WriteLine(node.value + " ");
            Inorder(node.right);
        }

        public static void Postorder(BinaryNode node)
        {
            if (node == null) return;
            Postorder(node.left);
            Postorder(node.right);
            Console.WriteLine(node.value + " ");
        }

        public static void LevelOrder(BinaryNode root)
        {
            if (root == null) return;

            var q = new Queue<BinaryNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                Console.Write(cur.value + " ");
                if (cur.left != null) q.Enqueue(cur.left);
                if (cur.right != null) q.Enqueue(cur.right);
            }
        }
    }
}
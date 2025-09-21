namespace AlgorithemInCSharp.Sorting
{
    public class SortingsInCSharp
    {
        public static void Buuble(int[] arr)
        {
            for (int start = arr.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j < start; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }

            Console.WriteLine($"{string.Join(",", arr)}");
        }

        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
            }
            Console.WriteLine($"{string.Join(",", arr)}");
        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int current = arr[i];
                while (j >= 0 && arr[j] < current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = current;
            }

            Console.WriteLine($"{string.Join(",", arr)}");
        }

        public static void MeregeSort(int[] arr)
        {
            if (arr.Length <= 1) return;
            int n = arr.Length;
            int mid = n / 2;
            int[] left = new int[mid];
            int[] right = new int[n - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, right.Length);

            MeregeSort(left);
            MeregeSort(right);
            Merge(arr, left, right);
        }

        private static void Merge(int[] result, int[] left, int[] right)
        {
            int p1 = 0, p2 = 0, p3 = 0;
            int n1 = left.Length;
            int n2 = right.Length;
            while (p1 < n1 && p2 < n2)
            {
                if (left[p1] < right[p2])
                {
                    result[p3] = left[p1];
                    p1++;
                }
                else
                {
                    result[p3] = right[p2];
                    p2++;
                }
                p3++;
            }

            while (p1 < n1)
            {
                result[p3] = left[p1];
                p1++;
                p3++;
            }

            while (p2 < n2)
            {
                result[p3] = right[p2];
                p2++;
                p3++;
            }

            Console.WriteLine($"{string.Join(",", result)}");
        }


        public static void QuickSort(int[] arr, int lo, int hi)
        {
            if (lo >= hi) return;
            int pi = Partition(arr, lo, hi);
            QuickSort(arr, lo, pi - 1);
            QuickSort(arr, pi + 1, hi);

            Console.WriteLine($"{string.Join(",", arr)}");
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[hi];
            int j = lo - 1;
            for (int i = lo; i < hi; i++)
            {
                if (arr[i] < pivot)
                {
                    j++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }

            }
            (arr[j + 1], arr[hi]) = (arr[hi], arr[j + 1]);

            return j + 1;
        }
    }

    public class TreeNode
    {
        public string Value;
        public List<TreeNode> Children = new List<TreeNode>();
        public TreeNode(string value)
        {
            Value = value;
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }


        public static void Run()
        {
            TreeNode root = new TreeNode("Baba");
            TreeNode omid = new TreeNode("Omid");
            TreeNode saeed = new TreeNode("Saeed");
            TreeNode vahid = new TreeNode("Vahid");
            TreeNode saleh = new TreeNode("Saleh");
            TreeNode samyar = new TreeNode("Samyar");

            root.AddChild(omid);
            root.AddChild(saeed);
            root.AddChild(vahid);
            omid.AddChild(saleh);
            omid.AddChild(samyar);
            PrintTree(root, 1);
        }

        private static void PrintTree(TreeNode root, int level)
        {
            Console.WriteLine($"{new string('-', level * 2)}{root.Value}");
            foreach (var child in root.Children)
            {
                PrintTree(child, level + 1);
            }
        }
    }


}
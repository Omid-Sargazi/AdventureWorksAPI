namespace DataStructure.Sorting
{
    public class StringExample
    {
        public static bool Run(string str)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (var item in str)
            {
                if (set.Contains(item))
                    return false;
                set.Add(item);
            }
            return true;
        }

        public static bool RunTwoFor(string str)
        {
            char[] ch = str.ToCharArray();
            bool equ = false;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (ch[i] == ch[j])
                        equ = true;
                }
            }
            return !equ;
        }
    }

    public class ReverseStringTwoPointers
    {
        public static string Reverse(string s)
        {

            char[] ch = s.ToCharArray();
            int i = 0; int j = ch.Length - 1;
            while (i < j)
            {
                (ch[i], ch[j]) = (ch[j], ch[i]);
                i++; j--;
            }

            Console.WriteLine(new string(ch));

            return new string(ch);
        }

        public static string ReversByCreating(string s)
        {
            if (s is null) return null;

            return string.Create(s.Length, s, static (span, src) =>
            {
                for (int i = 0, j = src.Length - 1; i < span.Length; i++, j--)
                    span[i] = src[j];
            });
        }
    }

    public class ReverseStringStack
    {
        public static string Reverse(string s)
        {
            if (s is null) return null;

            var st = new Stack<char>(s.Length);

            foreach (var item in s)
            {
                st.Push(item);
            }

            var chars = new char[s.Length];
            int i = 0;
            while (st.Count > 0) chars[i++] = st.Pop();
            return new string(chars);
        }
    }

    public class ReverseStringRec
    {
        public static string Reverse(string s) => s is null ? null :Rev(s,0,s.Length-1);

        private static string Rev(string s, int i, int j)
        {
            if (i >= j) return s;
            char[] chars = s.ToCharArray();
            (chars[i], chars[j]) = (chars[j], chars[i]);
            return Rev(new string(chars), i++, j--);
        }
    }
}
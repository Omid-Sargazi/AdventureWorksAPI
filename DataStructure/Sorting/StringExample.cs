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

    public  class ReverseStringTwoPointers
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
    }
}
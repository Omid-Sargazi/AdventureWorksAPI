namespace StandardExamples.Problems1
{
    public class LeetCodeProblems
    {
        public static bool Palindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            string clean = s.ToLower();

            while (left < right)
            {
                while (left < right && IsValidChar(clean[left])) left++;
                while (left < right && IsValidChar(clean[right])) right--;


                if (clean[left] != clean[right]) return false;

                left++;right--;
            }
            return true;
        }
        
        private static bool IsValidChar(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
        }
    }
}
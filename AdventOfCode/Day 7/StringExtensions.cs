namespace Day_7
{
    internal static class StringExtensions
    {
        public static bool HasAbba(this string s)
        {
            if (s.Length < 4) return false;

            for (var i = 0; i < s.Length - 3; i++)
            {
                if (s[i] == s[i + 3])
                {
                    if (s[i + 1] == s[i + 2] && s[i] != s[i + 1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

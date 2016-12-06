using System;

namespace Day_5
{
    internal static class Program
    {
        private static void Main()
        {
            var solution = new Solution();
            solution.Solve();

            Console.Read();
        }
    }

    internal class Solution
    {
        private const string Input = "cxdnnyjw";

        public void Solve()
        {
            var password = string.Empty;

            for (var i = 0; password.Length < 8; i++)
            {
                var encoded = Util.HashMd5(Input + i);

                if (encoded.Substring(0, 5) == "00000")
                {
                    password += encoded[5];
                }
            }

            Console.WriteLine("*: " + password);
        }
    }
}

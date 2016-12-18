using System;
using System.IO;
using System.Linq;

namespace Day_9
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
        private string _data = string.Empty;

        public void Solve()
        {
            _data = File.ReadAllText("../../input.txt").Trim();

            Console.WriteLine("Answers: ");
            Console.WriteLine(Decompress(_data));
        }

        private long Decompress(string input)
        {
            long output = 0;
            var i = 0;

            while (i < input.Length)
            {
                var ch = input[i];
                i++;

                if (ch != '(')
                {
                    output++;
                    continue;
                }

                //First param of the marker
                var tmp = new string(input.Skip(i).TakeWhile(c => c != 'x').ToArray());
                var repetitionLength = int.Parse(tmp);
                i += tmp.Length + 1;


                //Second param of the marker
                tmp = new string(input.Skip(i).TakeWhile(c => c != ')').ToArray());
                var repetitionCount = int.Parse(tmp);
                i += tmp.Length + 1;

                var data = input.Substring(i, repetitionLength);
                output += data.Length*repetitionCount;

                i += repetitionLength;
            }

            return output;
        }
    }
}
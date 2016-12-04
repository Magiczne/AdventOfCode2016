using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day_3
{
    internal static class Program
    {
        private static void Main()
        {
            var solution = new OneStarSolution();
            solution.Solve();

            Console.Read();
        }
    }

    internal class OneStarSolution
    {
        private readonly List<List<int>> _data = new List<List<int>>();

        public void Solve()
        {
            GetInput();

            var possible = _data.Count(IsValidTriangle);

            Console.WriteLine("*: " + possible);
        }

        private void GetInput()
        {
            using (var stream = File.OpenRead("../../input.txt"))
            {
                using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var clean = line.Trim();
                        clean = Regex.Replace(clean, @"\s+", " ");

                        var sides = clean.Split(new[] {" "}, StringSplitOptions.None);

                        var list = new List<int>()
                        {
                            int.Parse(sides[0]),
                            int.Parse(sides[1]),
                            int.Parse(sides[2])
                        };

                        list.Sort();

                        _data.Add(list);
                    }
                }
            }
        }

        private static bool IsValidTriangle(IReadOnlyList<int> sides)
        {
            return sides[0] + sides[1] > sides[2];
        }
    }
}

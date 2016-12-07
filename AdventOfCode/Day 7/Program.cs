using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_7
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
        private readonly List<IpAddress> _ips = new List<IpAddress>();

        public void Solve()
        {
            var lines = File.ReadAllLines("../../input.txt");

            foreach (var line in lines)
            {
                _ips.Add(new IpAddress(line));
            }

            var supportsTls = _ips.Count(ip => ip.SupportsTls);

            Console.WriteLine("Answers: ");
            Console.WriteLine("*: " + supportsTls);
        }
    }
}
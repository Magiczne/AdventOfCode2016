﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_7
{
    internal class IpAddress
    {
        private readonly List<string> _sequences = new List<string>();
        private readonly List<string> _hypernetSequences = new List<string>();

        public bool SupportsTls
        {
            get
            {
                return !_hypernetSequences.Any(seq => seq.HasAbba()) && _sequences.Any(seq => seq.HasAbba());
            }
        }

        public IpAddress(string line)
        {
            line = line.Trim();

            var regex = new Regex(@"([a-z]+)(?:[[]([a-z]+)[]])?");

            var matches = regex.Matches(line);

            foreach(Match match in matches)
            {
                for(var i = 1; i < match.Groups.Count; i++)
                {
                    if (match.Groups[i].ToString() == string.Empty) continue;

                    if(i % 2 == 1)
                    {
                        _sequences.Add(match.Groups[i].ToString());
                    }
                    else
                    {
                        _hypernetSequences.Add(match.Groups[i].ToString());
                    }
                }
            }
        }
    }

    internal static class StringExtensions
    {
        public static bool HasAbba(this string s)
        {
            if (s.Length < 4) return false;

            for(var i = 0; i < s.Length - 3; i++)
            {
                if(s[i] == s[i + 3])
                {
                    if(s[i+1] == s[i+2] && s[i] != s[i+1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
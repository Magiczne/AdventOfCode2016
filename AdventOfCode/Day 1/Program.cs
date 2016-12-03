using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    internal static class Program
    {
        private const string Input =
            "L4, L3, R1, L4, R2, R2, L1, L2, R1, R1, L3, R5, L2, R5, L4, L3, R2, R2, L5, L1, R4, L1, R3, L3, R5, R2, L5, R2, R1, R1, L5, R1, L3, L2, L5, R4, R4, L2, L1, L1, R1, R1, L185, R4, L1, L1, R5, R1, L1, L3, L2, L1, R2, R2, R2, L1, L1, R4, R5, R53, L1, R1, R78, R3, R4, L1, R5, L1, L4, R3, R3, L3, L3, R191, R4, R1, L4, L1, R3, L1, L2, R3, R2, R4, R5, R5, L3, L5, R2, R3, L1, L1, L3, R1, R4, R1, R3, R4, R4, R4, R5, R2, L5, R1, R2, R5, L3, L4, R1, L5, R1, L4, L3, R5, R5, L3, L4, L4, R2, R2, L5, R3, R1, R2, R5, L5, L3, R4, L5, R5, L3, R1, L1, R4, R4, L3, R2, R5, R1, R2, L1, R4, R1, L3, L3, L5, R2, R5, L1, L4, R3, R3, L3, R2, L5, R1, R3, L3, R2, L1, R4, R3, L4, R5, L2, L2, R5, R1, R2, L4, L4, L5, R3, L4";

        private static Direction _currentDirection = Direction.North;

        private static int _distanceVertical;
        private static int _distanceHorizontal;

        private static bool _crossingFound;
        private static Point _firstCrossed;
        private static readonly List<Point> Visited = new List<Point>();

        private static void Main()
        {
            var instructions = Input.Split(new[] {", "}, StringSplitOptions.None);

            foreach (var i in instructions)
            {
                if (i[0] == 'R') _currentDirection++;
                else _currentDirection--;

                if (_currentDirection > (Direction) 4) _currentDirection = Direction.North;
                if (_currentDirection < (Direction) 1) _currentDirection = Direction.West;

                var steps = int.Parse(i.Substring(1));

                for (var j = 1; j <= steps; j++)
                {
                    switch (_currentDirection)
                    {
                        case Direction.North:
                            _distanceVertical++;
                            break;
                        case Direction.West:
                            _distanceHorizontal--;
                            break;
                        case Direction.South:
                            _distanceVertical--;
                            break;
                        case Direction.East:
                            _distanceHorizontal++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    var point = new Point(_distanceHorizontal, _distanceVertical);

                    if (!_crossingFound)
                    {
                        if (Visited.Contains(point))
                        {
                            _firstCrossed = point;
                            _crossingFound = true;
                        }
                    }

                    Visited.Add(point);
                }
            }

            Console.WriteLine("Answers: ");
            Console.WriteLine("*: " + Visited.Last().Distance);
            Console.Write("**: " + _firstCrossed.Distance);

            Console.Read();
        }
    }
}
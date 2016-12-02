using System;

namespace AdventOfCode
{
    class Program
    {
        private const string Input = "L4, L3, R1, L4, R2, R2, L1, L2, R1, R1, L3, R5, L2, R5, L4, L3, R2, R2, L5, L1, R4, L1, R3, L3, R5, R2, L5, R2, R1, R1, L5, R1, L3, L2, L5, R4, R4, L2, L1, L1, R1, R1, L185, R4, L1, L1, R5, R1, L1, L3, L2, L1, R2, R2, R2, L1, L1, R4, R5, R53, L1, R1, R78, R3, R4, L1, R5, L1, L4, R3, R3, L3, L3, R191, R4, R1, L4, L1, R3, L1, L2, R3, R2, R4, R5, R5, L3, L5, R2, R3, L1, L1, L3, R1, R4, R1, R3, R4, R4, R4, R5, R2, L5, R1, R2, R5, L3, L4, R1, L5, R1, L4, L3, R5, R5, L3, L4, L4, R2, R2, L5, R3, R1, R2, R5, L5, L3, R4, L5, R5, L3, R1, L1, R4, R4, L3, R2, R5, R1, R2, L1, R4, R1, L3, L3, L5, R2, R5, L1, L4, R3, R3, L3, R2, L5, R1, R3, L3, R2, L1, R4, R3, L4, R5, L2, L2, R5, R1, R2, L4, L4, L5, R3, L4";

        private static int DistanceVertical { get; set; } = 0;

        private static int DistanceHorizontal { get; set; } = 0;

        private static Direction _currentDirection = Direction.North;

        static void Main(string[] args)
        {
            var instructions = Input.Split(new[] { ", " }, StringSplitOptions.None);

            foreach (var i in instructions)
            {
                if (i[0] == 'R')
                {
                    _currentDirection++;
                }
                else
                {
                    _currentDirection--;
                }

                if (_currentDirection > (Direction) 4) _currentDirection = Direction.North;
                if (_currentDirection < (Direction) 1) _currentDirection = Direction.East;

                var steps = int.Parse(i.Substring(1));

                switch (_currentDirection)
                {
                    case Direction.North:
                        DistanceVertical += steps;
                        break;

                    case Direction.West:
                        DistanceHorizontal += steps;
                        break;

                    case Direction.South:
                        DistanceVertical -= steps;
                        break;

                    case Direction.East:
                        DistanceHorizontal -= steps;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Console.Write(DistanceVertical + DistanceHorizontal);

            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AoC.CSharp._2021
{
    public enum MovementDirection
    {
        None,
        Forward,
        Up,
        Down,
    }

    public readonly struct Movement
    {
        public MovementDirection Direction { get; }
        public int Distance { get; }

        public Movement(MovementDirection direction, int distance)
        {
            Direction = direction;
            Distance = distance;
        }

        public static Movement Parse(string s)
        {
            MovementDirection dir = MovementDirection.None;
            switch (s.Substring(0, s.IndexOf(' ')))
            {
                case "forward":
                    dir = MovementDirection.Forward;
                    break;
                case "up":
                    dir = MovementDirection.Up;
                    break;
                case "down":
                    dir = MovementDirection.Down;
                    break;
            }
            
            if(!int.TryParse(s.Substring(s.IndexOf(' ')), out var distance))
                throw new InvalidDataException($"Failed to parse {s.Substring(s.IndexOf(' '))} to distance");

            return new Movement(dir, distance);
        }
    }
    
    public class Day2 : IChallenge
    {
        public string SolvePart1(string input)
        {
            var currentPosition = new Point(0, 0);
            
            foreach (var movement in ParseMovements(Helper.SplitByNewLine(input)))
            {
                switch (movement.Direction)
                {
                    case MovementDirection.Forward:
                        currentPosition.X += movement.Distance;
                        break;
                    case MovementDirection.Up:
                        currentPosition.Y -= movement.Distance;
                        break;
                    case MovementDirection.Down:
                        currentPosition.Y += movement.Distance;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return (currentPosition.Y * currentPosition.X).ToString();
        }

        public string SolvePart2(string input)
        {
            var currentPosition = new Point(0, 0);
            int aim = 0;
            
            foreach (var movement in ParseMovements(Helper.FilterEmptyOrNull(Helper.SplitByNewLine(input)).ToList()))
            {
                switch (movement.Direction)
                {
                    case MovementDirection.Forward:
                        currentPosition.X += movement.Distance;
                        currentPosition.Y += (aim * movement.Distance);
                        break;
                    case MovementDirection.Up:
                        aim -= movement.Distance;
                        break;
                    case MovementDirection.Down:
                        aim += movement.Distance;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return (currentPosition.Y * currentPosition.X).ToString();
        }

        private IEnumerable<Movement> ParseMovements(List<string> input) =>
            input.Where(s => !string.IsNullOrWhiteSpace(s)).Select(Movement.Parse);
    }
}
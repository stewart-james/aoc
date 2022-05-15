using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC.CSharp._2015
{
    public class Day7 : IChallenge
    {
        public static (string, string) ParseSet(string[] s) => (s[0], s[2]);
        public static (string, string, string) ParseAND(string[] s) => (s[0], s[2], s[4]);
        public static (string, string, string) ParseOR(string[] s) => (s[0], s[2], s[4]);
        public static (string, int, string) ParseLShift(string[] s) => (s[0], int.Parse(s[2]), s[4]);
        public static (string, int, string) ParseRShift(string[] s) => ParseLShift(s);
        public static (string, string) ParseNOT(string[] s) => (s[1], s[3]);

        public static bool IsSet(string[] s) => s.Length == 3;
        public static bool IsAnd(string[] s) => s.Length == 5 && s[1] == "AND";
        public static bool IsOr(string[] s) => s.Length == 5 && s[1] == "OR";
        public static bool IsLShift(string[] s) => s.Length == 5 && s[1] == "LSHIFT";
        public static bool IsRShift(string[] s) => s.Length == 5 && s[1] == "RSHIFT";
        public static bool IsNOT(string[] s) => s.Length == 4 && s[0] == "NOT";
        
        private int GetVariableValue(string variable, Dictionary<string, string[]> instructionsByVariableName, Dictionary<string,int> solutions)
        {
            if (solutions.ContainsKey(variable))
                return solutions[variable];
            
            var instructions = instructionsByVariableName[variable];

            Func<int> func = () =>
            {
                if (IsSet(instructions))
                {
                    var instruction = ParseSet(instructions);
                    if (int.TryParse(instruction.Item1, out var value))
                        return value;

                    return GetVariableValue(instruction.Item1, instructionsByVariableName, solutions);
                }

                if (IsAnd(instructions))
                {
                    var instruction = ParseAND(instructions);

                    if (!int.TryParse(instruction.Item1, out var lhs))
                        lhs = GetVariableValue(instruction.Item1, instructionsByVariableName, solutions);

                    if (!int.TryParse(instruction.Item2, out var rhs))
                        rhs = GetVariableValue(instruction.Item2, instructionsByVariableName, solutions);

                    return lhs & rhs;
                }

                if (IsOr(instructions))
                {
                    var instruction = ParseOR(instructions);

                    if (!int.TryParse(instruction.Item1, out var lhs))
                        lhs = GetVariableValue(instruction.Item1, instructionsByVariableName, solutions);

                    if (!int.TryParse(instruction.Item2, out var rhs))
                        rhs = GetVariableValue(instruction.Item2, instructionsByVariableName, solutions);

                    return lhs | rhs;
                }

                if (IsLShift(instructions))
                {
                    var instruction = ParseLShift(instructions);

                    var lhs = GetVariableValue(instruction.Item1, instructionsByVariableName, solutions);

                    return lhs << instruction.Item2;
                }

                if (IsRShift(instructions))
                {
                    var instruction = ParseRShift(instructions);

                    var lhs = GetVariableValue(instruction.Item1, instructionsByVariableName, solutions);

                    return lhs >> instruction.Item2;
                }

                if (IsNOT(instructions))
                {
                    var instruction = ParseNOT(instructions);

                    var lhs = GetVariableValue(instruction.Item1, instructionsByVariableName, solutions);

                    return ~lhs;
                }
                
                throw new Exception("Unsupported instruction");
            };

            var result = func();

            solutions[variable] = result;
            return result;
        }

        public string SolvePart1(string input) => Solve(ParseInput(input), new Dictionary<string, int>());

        public string SolvePart2(string input) => Solve(ParseInput(input), new Dictionary<string, int> { { "b", 16076 } });

        private string Solve(Dictionary<string, string[]> instructions, Dictionary<string, int> solutions)
            => GetVariableValue("a", instructions, solutions).ToString();

        private static Dictionary<string, string[]> ParseInput(string input)
        {
            var dict = new Dictionary<string, string[]>();

            var inputs = input
                .Split('\n')
                .Select(s => s.Split(' '))
                .ToList();

            foreach (var instructions in inputs)
            {
                if (IsSet(instructions))
                {
                    var instruction = ParseSet(instructions);
                    dict[instruction.Item2] = instructions;
                    continue;
                }

                if (IsOr(instructions) || IsAnd(instructions))
                {
                    var instruction = ParseOR(instructions);
                    dict[instruction.Item3] = instructions;
                    continue;
                }

                if (IsLShift(instructions) || IsRShift(instructions))
                {
                    var instruction = ParseLShift(instructions);
                    dict[instruction.Item3] = instructions;
                    continue;
                }

                if (IsNOT(instructions))
                {
                    var instruction = ParseNOT(instructions);
                    dict[instruction.Item2] = instructions;
                    continue;
                }

                throw new Exception("Unsupported instruction");
            }

            return dict;
        }
    }
}
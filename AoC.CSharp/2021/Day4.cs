using System;
using System.Linq;

namespace AoC.CSharp._2021
{
    public class BingoBoard
    {
        private class BoardCell
        {
            public int Number { get; set; }
            public bool WasCalled { get; private set; }

            public BoardCell(int num)
            {
                Number = num;
            }

            public void CallNumber(int number)
            {
                if (number == Number)
                    WasCalled = true;
            }
        }

        private class BoardRow
        {
            private BoardCell[] _cells;

            public BoardRow(int[] numbers)
            {
                if (numbers is null)
                    throw new ArgumentNullException(nameof(numbers));

                if (numbers.Length != 5)
                    throw new ArgumentException($"Expected 5 numbers but received {numbers.Length}");

                _cells = numbers.Select(n => new BoardCell(n)).ToArray();
            }

            public void CallNumber(int num)
            {
                foreach(var cell in _cells)
                    cell.CallNumber(num);
            }
            
            public bool HasWon() => _cells.All(c => c.WasCalled);

            public bool CellHasWon(int subscript)
            {
                if (subscript < 0 || subscript >= _cells.Length)
                    throw new ArgumentOutOfRangeException(nameof(subscript), subscript, "invalid subscript passed to CellHasWon");

                return _cells[subscript].WasCalled;
            }

            public int UnmarkedSum() => _cells.Where(c => !c.WasCalled).Select(c => c.Number).Sum();
        }

        private readonly BoardRow[] _rows;

        public BingoBoard(int[] numbers)
        {
            if (numbers is null)
                throw new ArgumentNullException(nameof(numbers));
            
            if (numbers.Length != 25)
                throw new ArgumentException($"Expected 25 numbers but {numbers.Length} was provided");

            _rows = new BoardRow[5];
            for (int i = 0; i < 5; ++i)
                _rows[i] = new BoardRow(numbers.Skip(i * 5).Take(5).ToArray());
        }

        public void CallNumber(int num)
        {
            foreach (var row in _rows)
                row.CallNumber(num);
        }

        public bool HasWon()
        {
            if (_rows.Any(r => r.HasWon()))
                return true;
            
            for(int i = 0; i < _rows.Length; ++i)
                if (ColumnWon(i))
                    return true;

            return false;
        }

        public int UnmarkedSum()
            => _rows.Sum(r => r.UnmarkedSum());

        private bool ColumnWon(int col) => _rows.All(r => r.CellHasWon(col));
    }

    public class Day4 : IChallenge
    {
        public string SolvePart1(string input)
        {
            var firstLineSubscript = input.IndexOf('\n');
            var calledNumbers = input.Substring(0, firstLineSubscript).Split(",").Select(int.Parse);

            var boards = Parse(input.Substring(firstLineSubscript));

            foreach (var num in calledNumbers)
            {
                foreach (var board in boards)
                {
                    board.CallNumber(num);

                    if (board.HasWon())
                        return (board.UnmarkedSum() * num).ToString();
                }
            }

            throw new Exception("Failed to find solution");
        }
        
        public static BingoBoard[] Parse(string input)
        {
            return input
                .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s
                    .Replace("\n", " ")
                    .Replace("  ", " ")
                    .Trim()
                    .Split(" ")
                    .Select(int.Parse)).Select(e => new BingoBoard(e.ToArray())).ToArray();
        }

        public string SolvePart2(string input)
        {
            var firstLineSubscript = input.IndexOf('\n');
            var calledNumbers = input.Substring(0, firstLineSubscript).Split(",").Select(int.Parse);

            var boards = Parse(input.Substring(firstLineSubscript));

            foreach (var num in calledNumbers)
            {
                var losingBoards = boards.Where(b => !b.HasWon()).ToList();
                int wonCount = 0;

                foreach (var board in losingBoards)
                {
                    board.CallNumber(num);

                    if (board.HasWon())
                        wonCount++;
                    
                    if(losingBoards.Count - wonCount == 0)
                        return (board.UnmarkedSum() * num).ToString();
                }
            }

            throw new Exception("Could not find part 2 solution");
        }
    }
}
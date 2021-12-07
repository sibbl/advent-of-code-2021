public static class Solution04
{
    private static Task<IEnumerable<IEnumerable<string>>> ReadInputAsync() => InputReader.ReadBlocksBetweenEmptyLinesAsync("Day04/input.txt");

    private class BingoField
    {
        public long Number { get; set; }
        public bool IsMarked { get; set; }

        public BingoField(long number)
        {
            Number = number;
            IsMarked = false;
        }
    }

    private class BingoBoard
    {
        private readonly BingoField[,] _board;

        public BingoBoard(BingoField[,] board)
        {
            _board = board;
        }

        public void Mark(long number)
        {
            foreach (var field in _board)
            {
                if (field.Number == number)
                {
                    field.IsMarked = true;
                }
            }
        }

        public IEnumerable<long> GetUnmarkedNumbers()
        {
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    var field = _board[i, j];
                    if (field.IsMarked == false) yield return field.Number;
                }
            }
        }

        public bool IsWinning()
        {
            for (var i = 0; i < 5; i++)
            {
                var winningRow = Enumerable.Range(0, 5).Select(x => _board[i, x]).ToArray();
                if (winningRow.All(x => x.IsMarked)) return true;

                var winningCol = Enumerable.Range(0, 5).Select(x => _board[x, i]).ToArray();
                if (winningCol.All(x => x.IsMarked)) return true;
            }

            return false;
        }
    }

    #region Problem One

    public static async Task<long> ProblemOneAsync(IEnumerable<IEnumerable<string>>? input = null)
    {
        input ??= await ReadInputAsync();

        var (bingoNumbers, boards) = ParseBoardList(input);

        foreach (var number in bingoNumbers)
        {
            foreach (var board in boards)
            {
                board.Mark(number);
                if (board.IsWinning())
                {
                    return board.GetUnmarkedNumbers().Sum() * number;
                }
            }
        }

        throw new Exception("No single solution found.");
    }

    #endregion

    #region Problem Two

    public static async Task<long> ProblemTwoAsync(IEnumerable<IEnumerable<string>>? input = null)
    {
        input ??= await ReadInputAsync();

        var (bingoNumbers, boards) = ParseBoardList(input);

        foreach (var number in bingoNumbers)
        {
            foreach (var board in boards.ToArray())
            {
                board.Mark(number);
                if (board.IsWinning())
                {
                    if (boards.Count == 1)
                    {
                        return board.GetUnmarkedNumbers().Sum() * number;
                    }
                    boards.Remove(board);
                }
            }
        }

        throw new Exception("No single solution found.");
    }

    #endregion

    private static (long[], List<BingoBoard>) ParseBoardList(IEnumerable<IEnumerable<string>> input)
    {
        long[]? bingoNumbers = null;
        var boards = new List<BingoBoard>();
        foreach (var block in input)
        {
            if (bingoNumbers is null)
            {
                bingoNumbers = block.First().Split(",").Select(long.Parse).ToArray();
                continue;
            }

            var board = new BingoField[5, 5];
            var i = 0;
            foreach (var line in block)
            {
                var numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                var j = 0;
                foreach (var number in numbers)
                {
                    board[i, j] = new BingoField(number);
                    j++;
                }

                i++;
            }

            boards.Add(new BingoBoard(board));
        }

        return (bingoNumbers, boards);
    }

}
public static class Solution05
{
    private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day05/input.txt");

    private readonly record struct Vector(long X, long Y)
    {
        public static Vector operator +(Vector a, Vector b) => new(a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b) => new(a.X - b.X, a.Y - b.Y);

        public Vector GetDirection() => new(GetDirectionOfComponent(X), GetDirectionOfComponent(Y));

        private static long GetDirectionOfComponent(long component) => component switch
        {
            < 0 => -1,
            > 0 => 1,
            0 => 0
        };
    }
    private record struct Line(Vector From, Vector To);

    #region Problem One

    public static async Task<long> ProblemOneAsync(IEnumerable<string>? input = null)
    {
        input ??= await ReadInputAsync();
        return CountLineIntersectionsGreaterOrEqualTwo(input);
    }

    #endregion

    #region Problem Two

    public static async Task<long> ProblemTwoAsync(IEnumerable<string>? input = null)
    {
        input ??= await ReadInputAsync();
        return CountLineIntersectionsGreaterOrEqualTwo(input, true);
    }

    #endregion

    private static Line ParseLine(string input)
    {
        var parts = input.Split(" -> ");
        return new Line(ParseVector(parts[0]), ParseVector(parts[1]));
    }

    private static Vector ParseVector(string input)
    {
        var parts = input.Split(',');
        return new Vector(long.Parse(parts[0]), long.Parse(parts[1]));
    }

    private static long CountLineIntersectionsGreaterOrEqualTwo(IEnumerable<string> input, bool supportDiagonals = false)
    {
        var lines = input.Select(ParseLine)
            .Where(x => supportDiagonals || x.From.X == x.To.X || x.From.Y == x.To.Y)
            .ToList();
        var maxX = lines.SelectMany(x => new[] { x.From.X, x.To.X }).Max();
        var maxY = lines.SelectMany(x => new[] { x.From.Y, x.To.Y }).Max();
        var ocean = new int[maxX + 1, maxY + 1];

        foreach (var line in lines)
        {
            var vector = (line.To - line.From).GetDirection();
            var position = line.From;
            ++ocean[position.X, position.Y];
            while (position != line.To)
            {
                position += vector;
                ++ocean[(int)position.X, (int)position.Y];
            }
        }

        return ocean.ToEnumerable().Count(x => x >= 2);
    }
}
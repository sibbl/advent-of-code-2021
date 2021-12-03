public static class Solution02
{
    private static async Task<string[]> ReadInputAsync() => (await InputReader.ReadLinesAsync("Day02/input.txt")).ToArray();

    private record struct Submarine
    {
        public long HorizontalPosition { get; set; }
        public long Aim { get; set; }
        public long Depth { get; set; }
    }


    private enum Direction
    {
        Forward,
        Up,
        Down
    };

    private record struct Instruction
    {
        public Direction Direction { get; set; }
        public long Value { get; set; }
        public Instruction(Direction direction, long value) => (Direction, Value) = (direction, value);
    }

    #region Problem One

    public static async Task<long> ProblemOneAsync(string[]? input = null)
    {
        input ??= await ReadInputAsync();
        var position = new Submarine();
        foreach (var instruction in input.Select(ParseInstruction))
        {
            switch (instruction.Direction)
            {
                case Direction.Forward:
                    position.HorizontalPosition += instruction.Value;
                    break;
                case Direction.Up:
                    position.Depth -= instruction.Value;
                    break;
                case Direction.Down:
                    position.Depth += instruction.Value;
                    break;
            }
        }
        return position.HorizontalPosition * position.Depth;
    }

    #endregion

    #region Problem Two

    public static async Task<long> ProblemTwoAsync(string[]? input = null)
    {
        input ??= await ReadInputAsync();
        var position = new Submarine();
        foreach (var instruction in input.Select(ParseInstruction))
        {
            switch (instruction.Direction)
            {
                case Direction.Forward:
                    position.HorizontalPosition += instruction.Value;
                    position.Depth += instruction.Value * position.Aim;
                    break;
                case Direction.Up:
                    position.Aim -= instruction.Value;
                    break;
                case Direction.Down:
                    position.Aim += instruction.Value;
                    break;
            }
        }
        return position.HorizontalPosition * position.Depth;
    }

    #endregion

    private static Instruction ParseInstruction(string inputLine)
    {
        var parts = inputLine.Split(' ');
        var direction = Enum.Parse<Direction>(parts[0], true);
        var value = long.Parse(parts[1]);
        return new Instruction(direction, value);
    }

}
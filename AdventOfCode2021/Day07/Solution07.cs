public static class Solution07
{
    private static Task<string> ReadInputAsync() => InputReader.ReadFileContent("Day07/input.txt");

    #region Problem One

    public static async Task<long> ProblemOneAsync(string? input = null)
    {
        input ??= await ReadInputAsync();
        return GetMinimumFuelConsumption(input, (position, targetPosition) => Math.Abs(targetPosition - position));
    }

    #endregion

    #region Problem Two

    public static async Task<long> ProblemTwoAsync(string? input = null)
    {
        input ??= await ReadInputAsync();
        return GetMinimumFuelConsumption(input, (position, targetPosition) =>
            Enumerable.Range(1, Math.Abs(targetPosition - position)).Sum());
    }

    #endregion

    private static long GetMinimumFuelConsumption(string input, Func<int, int, int> fuelFunction)
    {
        var positions = input.Split(',').Select(int.Parse).ToList();
        var (minPosition, maxPosition) = (positions.Min(), positions.Max());
        var minFuel = int.MaxValue;
        for (var targetPosition = minPosition; targetPosition < maxPosition; targetPosition++)
        {
            var fuel = positions.Sum(x => fuelFunction(x, targetPosition));
            if (fuel < minFuel) minFuel = fuel;
        }

        return minFuel;
    }
}
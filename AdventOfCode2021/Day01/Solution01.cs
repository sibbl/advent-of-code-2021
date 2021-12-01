public static class Solution01
{
    private static async Task<long[]> ReadInputAsync() => (await InputReader.ReadLinesAsLongsAsync("Day01/input.txt")).ToArray();

    #region Problem One

    public static async Task<long> ProblemOneAsync(long[]? input = null)
    {
        input ??= await ReadInputAsync();
        return CountIncreasesOfWindowSum(input);
    }

    #endregion

    #region Problem Two

    public static async Task<long> ProblemTwoAsync(long[]? input = null)
    {
        input ??= await ReadInputAsync();
        return CountIncreasesOfWindowSum(input, 3);
    }

    #endregion

    private static long CountIncreasesOfWindowSum(long[] input, int windowSize = 1)
    {
        var increases = 0;
        for (var i = windowSize; i < input.Length; i++)
        {
            if (input[i - windowSize] < input[i]) ++increases;
        }
        return increases;
    }
}
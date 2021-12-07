public static class Solution06
{
    private static Task<string> ReadInputAsync() => InputReader.ReadFileContent("Day06/input.txt");
    
    #region Problem One

    public static async Task<long> ProblemOneAsync(string? input = null)
    {
        input ??= await ReadInputAsync();
        var fishes = input.Split(',').Select(int.Parse).ToList();
        for (var i = 0; i < 80; i++)
        {
            var count = fishes.Count;
            for (var j = 0; j < count; j++)
            {
                fishes[j]--;
                if (fishes[j] >= 0) continue;
                fishes[j] = 6;
                fishes.Add(8);
            }
        }
        return fishes.Count;
    }

    #endregion

    #region Problem Two

    public static async Task<long> ProblemTwoAsync(string? input = null)
    {
        input ??= await ReadInputAsync();
        var initialState = input.Split(',').Select(int.Parse);
        var buckets = new long[9];

        foreach (var n in initialState)
        {
            ++buckets[n];
        }

        for (var i = 0; i < 256; i++)
        {
            var newFishes = buckets[0];
            for (var j = 0; j < 8; j++)
            {
                buckets[j] = buckets[j + 1];
            }

            buckets[6] += newFishes;
            buckets[8] = newFishes;
        }

        return buckets.Sum();
    }

    #endregion
}
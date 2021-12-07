using Xunit;

public class Day05
{
    [Theory]
    [InlineData(new [] {
        "0,9 -> 5,9",
        "8,0 -> 0,8",
        "9,4 -> 3,4",
        "2,2 -> 2,1",
        "7,0 -> 7,4",
        "6,4 -> 2,0",
        "0,9 -> 2,9",
        "3,4 -> 1,4",
        "0,0 -> 8,8",
        "5,5 -> 8,2"
    }, 5)]
    public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string[] input, long expectedOutput)
    {
        var output = await Solution05.ProblemOneAsync(input);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new[] {
        "0,9 -> 5,9",
        "8,0 -> 0,8",
        "9,4 -> 3,4",
        "2,2 -> 2,1",
        "7,0 -> 7,4",
        "6,4 -> 2,0",
        "0,9 -> 2,9",
        "3,4 -> 1,4",
        "0,0 -> 8,8",
        "5,5 -> 8,2"
    }, 12)]
    public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string[] input, long expectedOutput)
    {
        var output = await Solution05.ProblemTwoAsync(input);
        Assert.Equal(expectedOutput, output);
    }
}
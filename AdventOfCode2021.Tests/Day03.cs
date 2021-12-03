using Xunit;

public class Day03
{
    [Theory]
    [InlineData(new [] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" }, 198)]
    public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string[] input, long expectedOutput)
    {
        var output = await Solution03.ProblemOneAsync(input);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" }, 230)]
    public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string[] input, long expectedOutput)
    {
        var output = await Solution03.ProblemTwoAsync(input);
        Assert.Equal(expectedOutput, output);
    }
}
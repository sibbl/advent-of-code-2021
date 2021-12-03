using Xunit;

public class Day02
{
    [Theory]
    [InlineData(new [] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" }, 150)]
    public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string[] input, long expectedOutput)
    {
        var output = await Solution02.ProblemOneAsync(input);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" }, 900)]
    public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string[] input, long expectedOutput)
    {
        var output = await Solution02.ProblemTwoAsync(input);
        Assert.Equal(expectedOutput, output);
    }
}
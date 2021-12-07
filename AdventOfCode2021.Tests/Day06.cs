using Xunit;

public class Day06
{
    [Theory]
    [InlineData("3,4,3,1,2", 5934)]
    public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string input,
        long expectedOutput)
    {
        var output = await Solution06.ProblemOneAsync(input);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("3,4,3,1,2", 26984457539)]
    public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string input,
        long expectedOutput)
    {
        var output = await Solution06.ProblemTwoAsync(input);
        Assert.Equal(expectedOutput, output);
    }
}
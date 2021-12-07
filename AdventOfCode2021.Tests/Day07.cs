using Xunit;

public class Day07
{
    [Theory]
    [InlineData("16,1,2,0,4,2,7,1,2,14", 37)]
    public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string input,
        long expectedOutput)
    {
        var output = await Solution07.ProblemOneAsync(input);
        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("16,1,2,0,4,2,7,1,2,14", 168)]
    public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string input,
        long expectedOutput)
    {
        var output = await Solution07.ProblemTwoAsync(input);
        Assert.Equal(expectedOutput, output);
    }
}
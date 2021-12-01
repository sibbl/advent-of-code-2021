using AdventOfCode2021.Day01;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2021.Tests
{
    public class Day01
    {
        [Theory]
        [InlineData(new long[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 7)]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(long[] input, long expectedOutput)
        {
            var output = await Solution01.ProblemOneAsync(input);
            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(new long[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 5)]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(long[] input, long expectedOutput)
        {
            var output = await Solution01.ProblemTwoAsync(input);
            Assert.Equal(expectedOutput, output);
        }
    }
}

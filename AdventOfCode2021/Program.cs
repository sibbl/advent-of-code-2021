using System;
using System.Threading.Tasks;

await PrintSolution(1, 1, () => AdventOfCode2021.Day01.Solution01.ProblemOneAsync());
await PrintSolution(1, 2, () => AdventOfCode2021.Day01.Solution01.ProblemTwoAsync());

static async Task PrintSolution(int day, int problem, Func<Task<long>> solutionFunc)
{
    var output = await solutionFunc();
    Console.WriteLine($"Day {day}, Problem {problem}: {output}");
};
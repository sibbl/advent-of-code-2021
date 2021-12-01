await PrintSolution(1, 1, () => Solution01.ProblemOneAsync());
await PrintSolution(1, 2, () => Solution01.ProblemTwoAsync());

static async Task PrintSolution(int day, int problem, Func<Task<long>> solutionFunc)
{
    var output = await solutionFunc();
    Console.WriteLine($"Day {day}, Problem {problem}: {output}");
};
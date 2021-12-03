await PrintSolution(1, 1, () => Solution01.ProblemOneAsync());
await PrintSolution(1, 2, () => Solution01.ProblemTwoAsync());
await PrintSolution(2, 1, () => Solution02.ProblemOneAsync());
await PrintSolution(2, 2, () => Solution02.ProblemTwoAsync());
await PrintSolution(3, 1, () => Solution03.ProblemOneAsync());
await PrintSolution(3, 2, () => Solution03.ProblemTwoAsync());

static async Task PrintSolution(int day, int problem, Func<Task<long>> solutionFunc)
{
    var output = await solutionFunc();
    Console.WriteLine($"Day {day}, Problem {problem}: {output}");
};
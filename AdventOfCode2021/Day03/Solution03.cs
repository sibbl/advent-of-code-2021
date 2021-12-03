using System.ComponentModel.DataAnnotations;
using MoreLinq;

public static class Solution03
{
    private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day03/input.txt");


    #region Problem One

    public static async Task<long> ProblemOneAsync(IEnumerable<string>? input = null)
    {
        input ??= await ReadInputAsync();
        var charMap = input.Select(x => x.ToCharArray());
        var transposedCharMap = charMap.Transpose();

        var mostCommonBits = transposedCharMap.Select(x => x.GetMostOccurringElement()).ToArray();
        var mostCommonBitStr = new string(mostCommonBits);
        var mostCommonBitValue = mostCommonBitStr.ToLongFromBinary();

        var leastCommonBits = mostCommonBitStr.ToCharArray().Select(InvertBit).ToArray();
        var leastCommonBitStr = new string(leastCommonBits);
        var leastCommonBitValue = leastCommonBitStr.ToLongFromBinary();

        return mostCommonBitValue * leastCommonBitValue;
    }

    #endregion

    #region Problem Two

    public static async Task<long> ProblemTwoAsync(IEnumerable<string>? input = null)
    {
        input ??= await ReadInputAsync();

        return GetRating(input, true) * GetRating(input, false);
    }

    #endregion

    private static long GetRating(IEnumerable<string> input, bool findMostCommonBits)
    {
        var defaultBit = findMostCommonBits ? '1' : '0';

        var inputList = input.ToList();

        for (var i = 0; i < inputList.First().Length; i++)
        {
            var charMap = inputList.Select(x => x.ToCharArray());
            var transposedCharMap = charMap.Transpose().ToArray();

            var currentBits = transposedCharMap[i].ToArray();
            var targetBit = currentBits.GetMostOccurringElement(out var count);

            if (findMostCommonBits == false) targetBit = InvertBit(targetBit);

            var bitIsMajority = count * 2 > currentBits.Length;
            if (bitIsMajority == false) targetBit = defaultBit;

            inputList.RemoveAll(str => str[i] != targetBit);

            if (inputList.Count == 1)
            {
                return inputList[0].ToLongFromBinary();
            }
        }

        throw new Exception("No single solution found.");
    }

    private static char InvertBit(char bit) => bit == '1' ? '0' : '1';
}
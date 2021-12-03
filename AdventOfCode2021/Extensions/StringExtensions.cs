public static class StringExtensions
{
    /// <summary>
    /// Replace characters by specified map, where key will be replaced by value
    /// </summary>
    /// <param name="input">String to replace characters in</param>
    /// <param name="replacementDict"></param>
    /// <returns>String with replaced characters</returns>
    public static string ReplaceCharactersInString(this string input, IEnumerable<KeyValuePair<char, char>> replacementDict)
        => replacementDict.Aggregate(input, (current, value) => current.Replace(value.Key, value.Value));

    public static long ToLongFromBinary(this string input) => Convert.ToInt64(input, 2);
    public static long ToLongFromBinary(this char[] input) => ToLongFromBinary(new string(input));
}
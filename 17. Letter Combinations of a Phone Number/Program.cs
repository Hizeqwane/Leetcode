// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите число:");
    var digits = Console.ReadLine();

    Console.WriteLine();

    var d1 = DateTime.Now;
    var result = LetterCombinations(digits);
    var d2 = DateTime.Now;

    Console.WriteLine($"{nameof(LetterCombinations)}: {string.Join(',', result)}");
    Console.WriteLine("Время выполнения: {0}", d2 - d1);
}

IList<string> LetterCombinations(string digits)
{
    var d = new Dictionary<char, char[]>
    {
        {'2', new char[] {'a', 'b', 'c'}},
        {'3', new char[] {'d', 'e', 'f'}},
        {'4', new char[] { 'g', 'h', 'i' }},
        {'5', new char[] { 'j', 'k', 'l' }},
        {'6', new char[] { 'm', 'n', 'o' }},
        {'7', new char[] {'p', 'q', 'r', 's'}},
        {'8', new char[] { 't', 'u', 'v' }},
        {'9', new char[] {'w', 'x', 'y', 'z'}}
    };

    var result = new List<string>();

    foreach (var digit in digits)
    {
        if (result.Count == 0)
        {
            result = new List<string>(d[digit].Select(s => s.ToString()));
            continue;
        }

        var newRes = new List<string>();
        foreach (var res in result)
        {
            newRes.AddRange(d[digit].Select(s => res + s));
        }

        result = newRes;
    }

    return result;
}
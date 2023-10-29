// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using System.Text;

while (true)
{
    Console.WriteLine("Введите строку.");
    var s = Console.ReadLine();

    var result = LongestPalindromicSubstring(s);
    Console.WriteLine($"Самый длинный полиндром: {result}");
}

string LongestPalindromicSubstring(string s)
{

    var bestStart = 0;
    var bestEnd = 0;

    for (int j = 0; j < s.Length - 1; j++)
    {
        for (int i = Math.Max(j + 1, bestEnd - bestStart); i < s.Length; i++)
        {
            var start = j;
            var end = i;
            bool isPolind = true;
            while (start < end && isPolind)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    isPolind = false;
                }
            }

            if (isPolind && bestEnd - bestStart < i - j)
            {
                bestStart = j;
                bestEnd = i;
            }
        }
    }

    return s.Substring(bestStart, bestEnd - bestStart + 1);
}


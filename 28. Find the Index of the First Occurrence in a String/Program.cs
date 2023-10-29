// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

while (true)
{
    Console.WriteLine("Введите строку.");
    var haystack = Console.ReadLine();

    Console.WriteLine("Введите искомую подстроку.");
    var needle = Console.ReadLine();

    var d1 = DateTime.Now;
    var result = StrStr(haystack, needle);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.WriteLine($"{nameof(StrStr)}: {result}");

    Console.WriteLine();
}

int StrStr(string haystack, string needle)
{
    if (haystack.Length < needle.Length)
        return -1;

    for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
    {
        if (!needle.Where((t, j) => haystack[i + j] != t).Any())
            return i;
    }

    return -1;
}
// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите строку.");
    var s = Console.ReadLine();

    Console.WriteLine("Введите регулярное выражение.");
    var p = Console.ReadLine();

    var result = IsMatch(s, p);
    Console.WriteLine($"IsMatch: {result}");
}

bool IsMatch(string s, string p)
{
    return IsMatchHelper(s, p, s.Length - 1, p.Length - 1);
}

bool IsMatchHelper(string s, string p, int si, int pi)
{
    if (si < 0)
    {
        while (pi > 0 && p[pi] == '*') 
            pi -= 2;

        return pi < 0;
    }

    if (pi < 0)
        return false;

    if (s[si] == p[pi] || p[pi] == '.')
        return IsMatchHelper(s, p, --si, --pi);

    if (p[pi] != '*')
        return false;

    pi--;

    while (pi >= 0 && si >= 0 && (s[si] == p[pi] || p[pi] == '.'))
    {
        if (IsMatchHelper(s, p, si, pi - 1))
            return true;

        si--;
    }

    return IsMatchHelper(s, p, si, --pi);
}
// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите строку.");
    var s = Console.ReadLine();

    Console.WriteLine("Введите паттерн.");
    var p = Console.ReadLine();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = IsMatch(s, p);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(IsMatch)}: {result}");
    
    Console.WriteLine();
}

bool IsMatch(string s, string p)
{
    var i = 0;
    var j = 0;
    var star = -1;
    var m = -1;

    while (i < s.Length)
    {
        if (j < p.Length && (p[j] == '?' || p[j] == s[i]))
        {
            i++;
            j++;

            continue;
        }

        if (j < p.Length && p[j] == '*')
        {
            star = j++;
            m = i;

            continue;
        }

        if (star >= 0)
        {
            j = star + 1;
            i = ++m;

            continue;
        }

        return false;
    }

    while (j < p.Length && p[j] == '*')
    {
        j++;
    }

    return j == p.Length;
}

// Не получилось правильно учесть звездочки - после встречи несоответсвия нужно возвращаться
// к позиции где была звездочка и вытаться сопоставить заново...
bool IsMatchНеПолучилосьДобить(string s, string p)
{
    var indS = 0;
    var indP = 0;

    if (s.Length == 0 && p.Replace("*", "").Length == 0) return true;

    while (indS < s.Length && indP < p.Length)
    {
        var qCount = 0;
        var hasStar = false;
        while (indP < p.Length && (p[indP] == '*' || p[indP] == '?'))
        {
            if (p[indP] == '*') 
                hasStar = true;
            if (p[indP++] == '?')
                qCount++;
        }

        indS += qCount;
        if (indS == s.Length && indP == p.Length) return true;

        if (hasStar)
            while (indS < s.Length && (indP == p.Length || p[indP] != s[indS]))
                indS++;

        if (indS == s.Length && indP == p.Length) return true;

        if (s[indS] == p[indP])
        {
            indS++;
            indP++;
        }
        else
            return false;
    }

    return indS == s.Length && indP == p.Length;
}

// aaasdad
// *?s*  *?d?*
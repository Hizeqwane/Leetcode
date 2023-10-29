// See https://aka.ms/new-console-template for more information
while (true)
{
    Console.WriteLine("Введите строку.");
    var s = Console.ReadLine();

    var result = LongestSubstringWithoutRepeatingCharacters(s);
    Console.WriteLine($"Длина самой длинной подстроки: {result}");
}

int LongestSubstringWithoutRepeatingCharacters(string s)
{
    if (s.Length == 0)
        return 0;
    HashSet<char> h = new HashSet<char>();
    int b = 0;
    int e = 0;
    int m = 0;
    while (e < s.Length)
    {
        if (h.Add(s[e]))
        {
            e++;
            m = Math.Max(m, h.Count);
        }
        else
        {
            h.Remove(s[b]);
            b++;
        }
    }
    return m;
}
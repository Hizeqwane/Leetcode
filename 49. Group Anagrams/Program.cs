using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите анаграмы через запятую");
    var strs = Console.ReadLine().Split(",").ToArray();

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var result = GroupAnagrams(strs);
    stopWatch.Stop();

    Console.WriteLine("GroupAnagrams: Время выполнения: {0}", stopWatch.Elapsed);
    foreach (var res in result) 
        Console.WriteLine(string.Join(" , ", res));

    Console.WriteLine();
}

IList<IList<string>> GroupAnagrams(string[] strs)
{
    var dict = new Dictionary<string, IList<string>>();

    foreach (var str in strs)
    {
        var strArray = str.ToCharArray();
        Array.Sort(strArray);

        var key = new string(strArray);

        if (dict.ContainsKey(key)) 
            dict[key].Add(str);
        else
            dict.Add(key, new List<string> { str });
    }

    return dict.Values.ToList();
}
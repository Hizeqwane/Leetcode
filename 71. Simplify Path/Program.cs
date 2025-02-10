using System.Diagnostics;

Dictionary<string, string> tests = new()
{
    {"/home/", "/home"},
    {"/home//foo/", "/home/foo"},
    {"/home/user/Documents/../Pictures", "/home/user/Pictures"},
    {"/../", "/"},
    {"/.../a/../b/c/../d/./", "/.../b/d"},
};

foreach (var test in tests)
{
    var stopWatch = Stopwatch.StartNew();
    var result = SimplifyPath(test.Key);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(SimplifyPath)}: Время выполнения: {stopWatch.Elapsed}");

    var isOk = result == test.Value ? "OK" : "Failed";
    Console.WriteLine($"{result} - {test.Value} -> {isOk}");

    Console.WriteLine();   
}

string SimplifyPath(string path)
{
    return "";
}
using System.Diagnostics;

Dictionary<(string, string), int> tests = new()
{
    {("horse", "ros"), 3},
    {("intention", "execution"), 5},
};

foreach (var test in tests)
{
    var stopWatch = Stopwatch.StartNew();
    var result = minDistance(test.Key.Item1, test.Key.Item2);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(minDistance)}: Время выполнения: {stopWatch.Elapsed}");

    var isOk = result == test.Value ? "OK" : "Failed";
    Console.WriteLine($"{result} - {test.Value} -> {isOk}");

    Console.WriteLine();   
}

int minDistance(string word1, string word2)
{
    var n = word1.Length;
    var m = word2.Length;
    if (m > n) { return minDistance(word2, word1); }

    var dp = new int[n + 1, m + 1];
    for (var i = 0; i <= n; i++)
    {
        for (var j = 0; j <= m; j++)
        {
            if (i == 0)
            {
                dp[i, j] = j;
                continue;
            }
            if (j == 0)
            {
                dp[i, j] = i;
                continue;
            }

            if (word1[i - 1] == word2[j - 1])
            {
                dp[i, j] = dp[i - 1, j - 1];
                continue;
            }
            
            var insert = dp[i, j - 1] ;
            var delete = dp[i - 1, j];
            var replace = dp[i - 1, j - 1];
            dp[i, j] = Math.Min(replace, Math.Min(insert, delete)) + 1;
        }
    }

    return dp[n, m];
}
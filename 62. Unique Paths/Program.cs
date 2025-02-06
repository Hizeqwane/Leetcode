using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите числа");
    var nm = Console.ReadLine().Split(";").Select(int.Parse).ToArray();
    
    var stopWatch = Stopwatch.StartNew();
    var result = GetUniquePath(nm[0], nm[1]);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(GetUniquePath)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine(result);

    Console.WriteLine();
}

int GetUniquePath(int m, int n) {
    var dp = new int[m, n];
        
    for (var i = 0; i < m; i++)
        dp[i, 0] = 1;
    
    for (var j = 0; j < n; j++) 
        dp[0, j] = 1;
        
    for (var i = 1; i < m; i++)
        for (var j = 1; j < n; j++)
            dp[i, j] = dp[i-1, j] + dp[i, j-1];
        
    return dp[m-1, n-1];
}
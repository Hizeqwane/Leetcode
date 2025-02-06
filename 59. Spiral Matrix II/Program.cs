using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите число");
    var n = int.Parse(Console.ReadLine());
    
    var stopWatch = Stopwatch.StartNew();
    var result = GenerateMatrix(n);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(GenerateMatrix)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine("[" + string.Join(',', result.Select(s => "[" + string.Join(',', s) + "]")) + "]");

    Console.WriteLine();
}

int[][] GenerateMatrix(int n)
{
    var result = new int[n][];

    for (var i = 0; i < n; i++)
        result[i] = new int[n];

    for (var i = 1; i <= n * n; i++)
    {
        var circleNum = i / (4 * (n - 1) + 1) + 1;
        if (circleNum > 1)
            break;
        
        if (i < n + 1)
        {
            result[circleNum - 1][i - 1] = i;
            continue;
        }

        if (i < 2 * n)
        {
            result[i - n][n - 1] = i;
            continue;
        }
        
        if (i < 3 * n - 1)
        {
            result[n - 1][3 * n - 2 - i] = i;
            continue;
        }
        
        if (i < 4 * n - 1)
        {
            result[4 * n - 3 - i][n - n] = i;
            continue;
        }
    }
    
    return result;
}
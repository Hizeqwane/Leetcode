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
    if (n == 1)
        return new int[1][] { [1] };
    
    var result = new int[n][];

    for (var i = 0; i < n; i++)
        result[i] = new int[n];

    if (n % 2 == 1)
        result[n / 2][n / 2] = n * n;

    var circleNum = 0;
     
    var additionalSum = 0;
    
    for (var i = 1; i <= n * n; i++)
    {
        if (i == additionalSum + 1)
        {
            result[circleNum][circleNum] = i;
            continue;
        }
        
        var circleLength = 4 * (n - (2 * circleNum) - 1);
        var newCircleNum = (i - additionalSum) / (circleLength + 1);

        if (newCircleNum != 0)
        {
            additionalSum += circleLength;
            circleNum++;
        }

        var rebro = n - 1 - 2 * circleNum;
        
        if (i <= additionalSum + rebro)
        {
            result[circleNum][i - 1 - additionalSum + circleNum] = i;
            continue;
        }

        if (i <= additionalSum + 2 * rebro)
        {
            result[i - 1 - additionalSum - rebro + circleNum][n - circleNum - 1] = i;
            continue;
        }
        
        if (i <= additionalSum + 3 * rebro)
        {
            result[n - circleNum - 1][- (i - 1 - additionalSum - 3 * rebro - circleNum)] = i;
            continue;
        }
        
        if (i <= additionalSum + 4 * rebro) 
            result[- (i - 1 - additionalSum - 4 * rebro - circleNum)][circleNum] = i;
    }
    
    return result;
}
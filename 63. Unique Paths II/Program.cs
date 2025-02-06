using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите матрицу через запятую построчно");
    var firstRow = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
    
    var rowList = new List<int[]>{ firstRow };
    string row;
    while (!string.IsNullOrEmpty(row = Console.ReadLine()))
    {
        var rowArray = row.Split(',').Select(int.Parse).ToArray();
        rowList.Add(rowArray);
    }

    int[][] matrix = new int[rowList.Count][];
    int i = 0;
    foreach (var r in rowList) matrix[i++] = r;
    
    var stopWatch = Stopwatch.StartNew();
    var result = UniquePathsWithObstacles(matrix);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(UniquePathsWithObstacles)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine(result);

    Console.WriteLine();
}

int UniquePathsWithObstacles(int[][] obstacleGrid)
{
    var n = obstacleGrid.Length;
    var m = obstacleGrid.First().Length;

    if ((n == 1 || m == 1) && 
        obstacleGrid.SelectMany(s => s).Any(s => s == 1) ||
        obstacleGrid[0][0] == 1 || obstacleGrid[n - 1][m - 1] == 1)
        return 0;

    // Если в первой строке есть камень - все ячейки после него в строке должны быть 0
    // Для строки тоже самое
    var firstRowRock = Array.IndexOf(obstacleGrid[0], 1);
    if (firstRowRock >= 0)
        for (int j = firstRowRock; j < obstacleGrid[0].Length; j++)
        {
            obstacleGrid[0][j] = 1;
        }
    
    var firstColumnRock = obstacleGrid.Select(s => s.First()).ToList().IndexOf(1);
    if (firstColumnRock >= 0)
        for (int j = firstColumnRock; j < obstacleGrid.Length; j++)
        {
            obstacleGrid[j][0] = 1;
        }

    for (var i = 0; i < obstacleGrid.Length; i++)
    {
        for (var j = 0; j < obstacleGrid[i].Length; j++)
        {
            obstacleGrid[i][j] = Math.Abs(obstacleGrid[i][j] - 1);
        }
    }

    var dp = new int[n, m];
        
    for (var i = 0; i < n; i++)
        dp[i, 0] = 1 * obstacleGrid[i][0];
    
    for (var j = 0; j < m; j++) 
        dp[0, j] = 1 * obstacleGrid[0][j];
        
    for (var i = 1; i < n; i++)
    for (var j = 1; j < m; j++)
        dp[i, j] = (dp[i-1, j] + dp[i, j-1]) * obstacleGrid[i][j];
        
    return dp[n-1, m-1];
}
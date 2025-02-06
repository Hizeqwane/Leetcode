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
    var result = MinPathSum(matrix);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(MinPathSum)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine(result);

    Console.WriteLine();
}

int MinPathSum(int[][] grid)
{
    for (var i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (i == 0 && j == 0)
                continue;

            if (i == 0)
            {
                grid[i][j] += grid[i][j - 1];
                continue;
            }
            
            if (j == 0)
            {
                grid[i][j] += grid[i - 1][j];
                continue;
            }

            grid[i][j] += Math.Min(grid[i][j - 1], grid[i - 1][j]);
        }
    }

    return grid.Last().Last();
}
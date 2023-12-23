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
    var result = SpiralOrder(matrix);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(SpiralOrder)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine(string.Join(", ", result));

    Console.WriteLine();
}

IList<int> SpiralOrder(int[][] matrix)
{
    var rowCount = matrix.Length;
    var colCount = matrix[0].Length;

    var currentRow = 0;
    var currentCol = 0;

    var result = new List<int>
    {
        //matrix[0][0]
    };

    var currentMaxCol = colCount - 1;
    var currentMaxRow = rowCount - 1;

    var currentMinCol = 0;
    var currentMinRow = 0;

    var elCount = rowCount * colCount;

    while (result.Count < elCount)
    {
        for (var i = currentMinCol; i <= currentMaxCol && result.Count < elCount; i++)
        {
            result.Add(matrix[currentMinRow][i]);
        }

        currentMinCol++;

        for (var i = currentMinRow + 1; i <= currentMaxRow && result.Count < elCount; i++)
        {
            result.Add(matrix[i][currentMaxCol]);
        }

        currentMinRow++;

        for (var i = currentMaxCol - 1; i >= currentMinCol - 1 && result.Count < elCount; i--)
        {
            result.Add(matrix[currentMaxRow][i]);
        }

        currentMaxCol--;

        for (var i = currentMaxRow - 1; i >= currentMinRow && result.Count < elCount; i--)
        {
            result.Add(matrix[i][currentMinCol - 1]);
        }

        currentMaxRow--;
    }

    return result;
}
using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите изображение построчно - через запятую");
    var firstRow = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

    var matrix = new int[firstRow.Length][];
    matrix[0] = firstRow;
    for (int i = 1; i < firstRow.Length; i++)
        matrix[i] = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    Rotate(matrix);
    stopWatch.Stop();

    Console.WriteLine("Rotate: Время выполнения: {0}", stopWatch.Elapsed);
    foreach (var res in matrix) 
        Console.WriteLine(string.Join(" , ", res));

    Console.WriteLine();
}

void Rotate(int[][] matrix)
{
    var len = matrix.Length;
    var rowLimit = matrix.Length / 2;
    
    for (int row = 0; row <= rowLimit; row++)
    {
        var colLimit = matrix.Length - 1 - row;
        for (int col = row; col < colLimit; col++)
        {
            var temp = matrix[row][col];
            matrix[row][col] = matrix[len - 1 - col][row];
            matrix[len - 1 - col][row] = matrix[colLimit][len - 1 - col];
            matrix[colLimit][len - 1 - col] = matrix[col][colLimit];
            matrix[col][colLimit] = temp;
        }
    }
}
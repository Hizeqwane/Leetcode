using System.Diagnostics;
using System.Text;

string _q = "Q";

while (true)
{
    Console.WriteLine("Введите n");
    var n = int.Parse(Console.ReadLine());

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var result = SolveNQueens(n);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine("SolveNQueens: Время выполнения: {0}", stopWatch.Elapsed);
    foreach (var res in result) 
        Console.WriteLine(string.Join(" , ", res));

    Console.WriteLine();
}

IList<IList<string>> SolveNQueens(int n)
{
    if (n == 1) return new List<IList<string>>{ new List<string>{_q}};
    if (n < 4) return new List<IList<string>>();

    var result = new List<IList<string>>();

    //var firstQposCount = n % 2 == 0
    //    ? n / 2 : n / 2 + 1;

    var qState = new StringBuilder[n][];
    for (int i = 0; i < n; i++)
    {
        qState[i] = new StringBuilder[n];
        for (int j = 0; j < n; j++)
            qState[i][j] = new StringBuilder();
    }

    for (int firstQPosCol = 0; firstQPosCol < n; firstQPosCol++)
    {
        var qCount = 1;
        SetQ(qCount, 0, firstQPosCol, qState);

        BackTracking(n, qCount, qState, result);
        UnsetQ(qCount, 0, firstQPosCol, qState);
    }

    return result;
}

void BackTracking(int n, int qCount, StringBuilder[][] qState, IList<IList<string>> result)
{
    if (qCount == n)
    {
        result.Add
        (
            qState
                .Select
                (
                    row => string.Concat
                        (
                            row.Select(s => s.ToString())
                               .Select(s => s.Contains(_q) ? _q : "."))
                )
                .ToList()
        );
        return;
    }

    var row = qCount;
    for (int col = 0; col < n; col++)
    {
        if (qState[row][col].Length > 0)
            continue;

        SetQ(++qCount, row, col, qState);
        BackTracking(n, qCount, qState, result);
        UnsetQ(qCount--, row, col, qState);
    }
}

void UnsetQ(int qCount, int row, int col, StringBuilder[][] qState)
{
    var n = qState.GetLength(0);
    var qCountStr = qCount.ToString();

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == row && j == col) 
                qState[i][j].Replace("Q", "");

            qState[i][j].Replace(qCountStr, "");
        }
    }
}

void SetQ(int qCount, int row, int col, StringBuilder[][] qState)
{
    var n = qState.GetLength(0);

    for (int i = 0; i < n; i++)
    {
        if (i != row)
        {
            qState[i][col].Append(qCount);

            var diag1 = col - row + i;
            if (diag1 >= 0 && diag1 < n)
                qState[i][diag1].Append(qCount);

            var diag2 = col + row - i;
            if (diag2 >= 0 && diag2 < n)
                qState[i][diag2].Append(qCount);

            continue;
        }

        for (int j = 0; j < n; j++)
        {
            if (j == col) qState[i][j].Append("Q");
            qState[i][j].Append(qCount);
        }
    }
}

// Найдём решения для позиций первого ферзя в первой строке с 0 до 3, потом добавим к решению ещё транспонированные
// . . . . .
// . . . . .
// . . . . .
// . . . . .
// . . . . .
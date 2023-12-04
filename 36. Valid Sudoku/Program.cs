// See https://aka.ms/new-console-template for more information

while (true)
{
    char[][] board = new char[9][];
    Console.WriteLine("Введите доску построчно.");
    for (int i = 0; i < 9; i++) 
        board[i] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = IsValidSudoku(board);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(IsValidSudoku)}: {result}");
    
    Console.WriteLine();
}

bool IsValidSudoku(char[][] board)
{
    var checkCol = new HashSet<char>[9];

    var checkSquare = new HashSet<char>[3];
    checkSquare[0] = new HashSet<char>();
    checkSquare[1] = new HashSet<char>();
    checkSquare[2] = new HashSet<char>();

    var checkRow = new HashSet<char>();

    for (int row = 0; row < board.Length; row++)
    {
        for (int col = 0; col < board[row].Length; col++)
        {
            var d = board[row][col];
            if (d == '.') continue;

            checkCol[col] ??= new HashSet<char>();

            if (!checkRow.Add(d) || !checkCol[col].Add(d))
                return false;

            switch (col)
            {
                case < 3 when !checkSquare[0].Add(d):
                    return false;
                case >=3 and < 6 when !checkSquare[1].Add(d):
                    return false;
                case >= 6 when !checkSquare[2].Add(d):
                    return false;
            }

        }
        checkRow.Clear();

        if (row == 2 || row == 5)
            foreach (var square in checkSquare)
                square.Clear();
    }

    return true;
}
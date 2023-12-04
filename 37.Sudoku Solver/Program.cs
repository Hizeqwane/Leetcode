// See https://aka.ms/new-console-template for more information

while (true)
{
    char[][] board = new char[9][];
    Console.WriteLine("Введите доску построчно.");
    for (int i = 0; i < 9; i++) 
        board[i] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    SudokuSolve(board);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(SudokuSolve)}: ");

    foreach (var row in board)
    {
        foreach (var col in row)
        {
            Console.Write(col + " , ");
        }
        Console.WriteLine();
    }
    
    Console.WriteLine();
}

void SudokuSolve(char[][] board)
{
    Solve(board);
}

bool Solve(char[][] board)
{
    for (int row = 0; row < board.Length; row++)
    {
        for (int col = 0; col < board[row].Length; col++)
        {
            if (char.IsDigit(board[row][col]))
                continue;

            for (int i = 1; i < 10; i++)
            {
                board[row][col] = char.Parse(i.ToString());
                if (IsValidSudoku(board))
                    if (Solve(board))
                        return true;
            }

            board[row][col] = '.';
            return false;
        }
    }

    return true;
}

#region My solution
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
                case >= 3 and < 6 when !checkSquare[1].Add(d):
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
#endregion

#region Pretty solution
public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        bool temp = DFS(board, 0, 0);
    }

    private bool DFS(char[][] board, int row, int col)
    {
        if (row == 9) return true;
        if (col == 9) return DFS(board, row + 1, 0);
        if (board[row][col] != '.') return DFS(board, row, col + 1);

        for (char i = '1'; i <= '9'; i++)
        {
            if (!IsVaild(board, row, col, i)) continue;

            board[row][col] = i;
            if (DFS(board, row, col + 1)) return true;

            board[row][col] = '.';
        }

        return false;
    }

    private bool IsVaild(char[][] board, int row, int col, char k)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i][col] == k) return false;
        }

        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == k) return false;
        }

        int x = (row / 3) * 3;
        int y = (col / 3) * 3;
        for (int p = 0; p < 3; p++)
        {
            for (int q = 0; q < 3; q++)
            {
                if (board[p + x][q + y] == k) return false;
            }
        }

        return true;
    }
} 
#endregion
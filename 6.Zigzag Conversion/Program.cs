// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите строку.");
    var s = Console.ReadLine();
    Console.WriteLine("Введите количество строк.");
    var numRows = Console.ReadLine();

    var result = ZigzagConversion(s, int.Parse(numRows!));
    Console.WriteLine($"Зиг-заг: {result}");
}

string ZigzagConversion(string s, int numRows)
{
    if (numRows == 1)
        return s;

    StringBuilder result = new StringBuilder();

    var currentRow = 1;
    while (result.Length < s.Length)
    {
        var ind = currentRow - 1;
        var isColumn = true;

        while (ind < s.Length)
        {
            result.Append(s[ind]);
            var nextInd = isColumn ? ind + 2 * (numRows - currentRow) : ind + 2 * (currentRow - 1);
            ind = nextInd == ind ? ind + (numRows - 2) + numRows : nextInd;
            isColumn = currentRow == 1 || currentRow == numRows ? isColumn : !isColumn;
        }

        currentRow++;
    }

    return result.ToString();
}


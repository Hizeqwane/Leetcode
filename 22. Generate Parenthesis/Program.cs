// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите число.");
    var nStr = Console.ReadLine();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = GenerateParenthesis(int.Parse(nStr));
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(GenerateParenthesis)}: {string.Join(" , ", result)}");
    
    Console.WriteLine();
}

IList<string> GenerateParenthesis(int n)
{
    var numList = new List<byte[]>
    {
        new byte[2 * n]
    };
    var plusList = new List<byte>
    {
        0
    };
    var startList = new List<byte>
    {
        0
    };

    for (int i = 0; i < numList.Count; i++)
    {
        for (int j = startList[i]; j < 2 * n; j++)
        {
            if (j == 0 || numList[i][j - 1] == 0)
            {
                numList[i][j] = 1;
                plusList[i]++;
                continue;
            }

            if (plusList[i] == n)
            {
                numList[i][j] = (byte)(numList[i][j - 1] - 1);
                continue;
            }

            numList.Add((byte[])numList[i].Clone());
            plusList.Add(plusList[i]);
            startList.Add((byte)(j + 1));

            numList[i][j] = (byte)(numList[i][j - 1] - 1);
            numList[^1][j] = (byte)(numList[i][j - 1] + 1);
            plusList[^1]++;
        }
    }


    var result = new List<string>();
    foreach (var num in numList)
    {
        var str = new StringBuilder();
        for (int i = 0; i < num.Length; i++)
        {
            if (i == 0)
                str.Append("(");
            else
                str.Append(num[i] > num[i - 1] ? "(" : ")");
        }
        result.Add(str.ToString());
    }
    return result;
}

// 1210
// 1010

// 123210 - +1 +1 +1 -1 -1 -1 
// 121010 - +1 +1 -1 -1 +1 -1
// 121210 - +1 +1 -1 +1 -1 -1
// 101210 - +1 -1 +1 +1 -1 -1
// 101010 - +1 -1 +1 -1 +1 -1
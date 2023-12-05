// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите n.");
    var n = int.Parse(Console.ReadLine());
    
    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = CountAndSay(n);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(CountAndSay)}: {result}");
    
    Console.WriteLine();
}

string CountAndSay(int n)
{
    if (n == 1) return "1";

    var prev = CountAndSay(n - 1);
    var result = new StringBuilder();

    var curCount = 0;
    char currentChar = '.';
    for (var i = 0; i < prev.Length ; i++)
    {
        if (i == 0)
        {
            currentChar = prev[i];
            curCount++;

            if (i == prev.Length - 1)
            {
                result.Append(curCount.ToString() + currentChar);
                break;
            }

            continue;
        }

        if (i == prev.Length - 1 && prev[i] == currentChar)
        {
            result.Append((++curCount).ToString() + currentChar);
            break;
        }

        if (prev[i] == currentChar) 
            curCount++;
        else
        {
            result.Append(curCount.ToString() + currentChar);
            curCount = 1;
            currentChar = prev[i];

            if (i == prev.Length - 1)
            {
                result.Append(curCount.ToString() + currentChar);
                break;
            }
        }
    }

    return result.ToString();
}
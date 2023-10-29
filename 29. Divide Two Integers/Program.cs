// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

while (true)
{
    Console.WriteLine("Введите делимое.");
    var dividend = Console.ReadLine();

    Console.WriteLine("Введите делитель.");
    var divisor = Console.ReadLine();

    var d1 = DateTime.Now;
    var result = Divide(int.Parse(dividend), int.Parse(divisor));
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.WriteLine($"{nameof(Divide)}: {result}");

    Console.WriteLine();
}

int Divide(int dividend, int divisor)
{
    if (dividend == -2147483648 && divisor == -1)
        return int.MaxValue;

    bool sign = !(dividend < 0 && divisor > 0 || dividend > 0 && divisor < 0);

    var result = 0;
    var curDiv = dividend;

    if (sign && dividend >= 0)
    {
        while (curDiv >= divisor)
        {
            curDiv -= divisor;
            result++;
        }
    }
    else if (sign && dividend < 0)
    {
        while (curDiv <= divisor)
        {
            curDiv -= divisor;
            result++;
        }
    }
    else if (dividend >= 0)
    {
        result--;
        while (curDiv >= 0)
        {
            curDiv += divisor;
            result++;
        }
    }
    else
    {
        result--;
        while (curDiv <= 0)
        {
            curDiv += divisor;
            result++;
        }
    }

    return sign ? result : - result;
}
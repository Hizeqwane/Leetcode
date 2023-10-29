// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите число.");
    var x = Console.ReadLine();

    var result = ReverseInteger(int.Parse(x));
    Console.WriteLine($"Reverse: {result}");
}

int ReverseInteger(int x)
{
    bool sign = !(x < 0);
    if (x == -2147483648)
        return 0;

    var str = Math.Abs(x + 1).ToString().ToCharArray();

    Array.Reverse(str);

    if (!int.TryParse(sign ? str : "-" + new string(str), out var num))
        return 0;

    return num;
}
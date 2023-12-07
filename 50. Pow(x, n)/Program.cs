using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите x");
    var x = double.Parse(Console.ReadLine().Replace(".", ","));

    Console.WriteLine("Введите n");
    var n = int.Parse(Console.ReadLine());

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var result = MyPow(x ,n);
    stopWatch.Stop();

    Console.WriteLine("MyPow: {0} Время выполнения: {1}", result, stopWatch.Elapsed);

    Console.WriteLine();
}

double MyPow(double x, int n)
{
    return binaryExp(x, n);
}

double binaryExp(double x, long n)
{
    if (n == 0)
    {
        return 1;
    }

    if (n < 0)
    {
        return 1.0 / binaryExp(x, -1 * n);
    }


    if (n % 2 == 1)
    {
        return x * binaryExp(x * x, (n - 1) / 2);
    }
    else
    {
        return binaryExp(x * x, n / 2);
    }
}
using System.Diagnostics;
using System.Text;

var stopWatch = Stopwatch.StartNew();
var result = MySqrt(15);
stopWatch.Stop();

Console.WriteLine();
Console.WriteLine($"{nameof(MySqrt)}: Время выполнения: {stopWatch.Elapsed}");

Console.WriteLine(result);

Console.WriteLine();

int MySqrt(int x) {
    if (x == 0)
        return 0;

    int left = 1;
    int right = x;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;
        int sqrt = x / mid;

        if (sqrt == mid)
            return mid;
        else if (sqrt < mid)
            right = mid - 1;
        else
            left = mid + 1;
    }

    return right;
}
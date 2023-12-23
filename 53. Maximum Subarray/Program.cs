using System.Diagnostics;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    var stopWatch = Stopwatch.StartNew();
    var result = MaxSubArray(nums);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(MaxSubArray)}: Время выполнения: {stopWatch.Elapsed}");
    Console.WriteLine(result);

    Console.WriteLine();
}

int MaxSubArray(int[] nums)
{
    var max = nums[0];

    var currentSum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (currentSum + nums[i] > 0)
        {
            currentSum += nums[i];
            max = Math.Max(max, currentSum);
            continue;
        }

        currentSum = 0;
        max = Math.Max(max, nums[i]);
    }

    return max;
}

// -2  1 -3  4 -1  2  1 -5  4

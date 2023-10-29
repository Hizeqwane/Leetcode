// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var numsStr = Console.ReadLine();

    Console.WriteLine("Введите target.");
    var target = Console.ReadLine();

    Console.WriteLine();

    var nums = numsStr.Split(',').Select(s => int.Parse(s)).ToArray();

    var d1 = DateTime.Now;
    var result = ThreeSumClosest(nums, int.Parse(target));
    var d2 = DateTime.Now;

    Console.WriteLine($"3Sum Closest: {result}");
    Console.WriteLine("Время выполнения: {0}", d2 - d1);
}

int ThreeSumClosest(int[] nums, int target)
{
    Array.Sort(nums);
    var result = nums[0] + nums[1] + nums[2];

    if (result > target)
        return result;

    for (var i = 0; i < nums.Length - 2; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        var left = i + 1;
        var right = nums.Length - 1;

        while (left < right)
        {
            var sum = nums[i] + nums[left] + nums[right];

            if (sum == target)
                return target;

            if (Math.Abs(result - target) > Math.Abs(sum - target))
                result = sum;

            if (sum < target)
                left++;
            else
                right--;
        }
    }

    return result;
}
// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var numsStr = Console.ReadLine();

    Console.WriteLine();

    var nums = numsStr.Split(',').Select(s => int.Parse(s)).ToArray();

    var d1 = DateTime.Now;
    var result = OtherThreeSum(nums);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    //Console.WriteLine($"3Sum: {string.Join(';', result.Select(s => string.Join(',',s)))}");

    var d3 = DateTime.Now;
    var result1 = ThreeSum(nums);
    var d4 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d4 - d3);
    //Console.WriteLine($"3Sum: {string.Join(';', result.Select(s => string.Join(',', s)))}");
}

IList<IList<int>> ThreeSum(int[] nums)
{
    Array.Sort(nums);

    var result = new List<IList<int>>();

    for (int i = 0; i < nums.Length - 2 && nums[i] <= 0; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        int left = i + 1;
        int right = nums.Length - 1;

        for (int j = i + 1; j < nums.Length - 1; j++)
        {
            if (j > i + 1 && nums[j] == nums[j - 1])
                continue;

            for (int k = nums.Length - 1; k > j && nums[k] >= 0; k--)
            {
                if (k < nums.Length - 1 && nums[k] == nums[k + 1])
                    continue;

                if (nums[i] + nums[j] + nums[k] == 0)
                {
                    result.Add(new List<int> { nums[i], nums[j], nums[k] });
                    break;
                }
            }
        }
    }

    return result;
}

IList<IList<int>> OtherThreeSum(int[] nums)
{
    Array.Sort(nums);
    var result = new List<IList<int>>();

    for (var i = 0; i < nums.Length - 2; i++)
    {
        if (nums[i] > 0) break;

        if (i > 0 && nums[i] == nums[i - 1]) continue;

        var left = i + 1;
        var right = nums.Length - 1;

        while (left < right)
        {
            switch (nums[i] + nums[left] + nums[right])
            {
                case 0:
                {
                    result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                    do
                    {
                        left++;
                    }
                    while (left < right && nums[left - 1] == nums[left]);

                    do
                    {
                        right--;
                    }
                    while (left < right && nums[right] == nums[right + 1]);

                    break;
                }
                case < 0:
                    left++;
                    break;
                default:
                    right--;
                    break;
            }
        }
    }

    return result;
}
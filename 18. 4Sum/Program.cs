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
    var result = FourSum(nums, int.Parse(target));
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.WriteLine($"{nameof(FourSum)}: {string.Join(';', result.Select(s => string.Join(',',s)))}");
}

IList<IList<int>> FourSum(int[] nums, int target)
{
    Array.Sort(nums);
    var result = new List<IList<int>>();

    if (target < 0 && nums[0] >= 0)
        return result;

    for (var i = 0; i < nums.Length - 2; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        for (var left1 = i + 1; nums[left1] + nums[i] <= target && left1 < nums.Length - 1; left1++)
        {
            if (left1 > i + 1 && nums[left1] == nums[left1 - 1]) continue;

            var left2 = left1 + 1;
            var right = nums.Length - 1;

            while (left2 < right)
            {
                var sum = nums[i] + nums[left1] + nums[left2] + nums[right];

                if (sum == target)
                {
                    result.Add(new List<int>() { nums[i], nums[left1], nums[left2], nums[right] });
                    do
                    {
                        left2++;
                    }
                    while (left2 < right && nums[left2 - 1] == nums[left2]);

                    do
                    {
                        right--;
                    }
                    while (left1 < right && nums[right] == nums[right + 1]);
                }
                else if (sum < target)
                    left2++;
                else
                    right--;
            }
        }
    }

    return result;
}
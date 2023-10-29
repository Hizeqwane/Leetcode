// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

while (true)
{
    Console.WriteLine("Введите массив через запятую");
    var nums = Console.ReadLine().Split(",").Select(s => int.Parse(s)).ToArray();

    var d1 = DateTime.Now;
    NextPermutation(nums);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    foreach (var num in nums) 
        Console.Write(num + " ");

    Console.WriteLine();
}

void NextPermutation(int[] nums)
{
    if (nums.Length < 2)
        return;

    if (nums[^1] > nums[^2])
    {
        (nums[^1], nums[^2]) = (nums[^2], nums[^1]);
        return;
    }

    var end = nums.Length - 1;
    var index = -1;
    for (var i = end - 1; i > -1; i--)
        if (nums[i] < nums[i + 1])
        {
            index = i;
            break;
        }

    if (index == -1)
    {
        Array.Reverse(nums);
        return;
    }

    var indexForReplace = -1;
    var min = int.MaxValue;
    for (var i = end; i >= index + 1; i--)
        if (nums[i] > nums[index] && nums[i] < min)
        {
            min = nums[i];
            indexForReplace = i;
        }

    (nums[index], nums[indexForReplace]) = (nums[indexForReplace], nums[index]);
    Array.Reverse(nums, index + 1, end - index);
}
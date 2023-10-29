// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var numsStr = Console.ReadLine();

    var nums = numsStr.Split(',').Select(int.Parse).ToArray();

    var d1 = DateTime.Now;
    var result = RemoveDuplicates(nums);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.WriteLine($"{nameof(RemoveDuplicates)}: {result}");

    foreach (var num in nums) 
        Console.Write(num + " ");


    Console.WriteLine();
}

int RemoveDuplicates(int[] nums)
{
    var ind = 0;

    for (var i = 0; i < nums.Length; )
    {
        var j = i + 1;
        nums[ind] = nums[i];
        ind++;

        while (j < nums.Length && nums[i] == nums[j]) j++;

        i = j;
    }

    return ind;
}
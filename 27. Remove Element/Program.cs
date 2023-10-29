// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var numsStr = Console.ReadLine();

    var nums = numsStr.Split(',').Select(int.Parse).ToArray();

    Console.WriteLine("Введите число для удаления.");
    var valStr = Console.ReadLine();

    var d1 = DateTime.Now;
    var result = RemoveElement(nums, int.Parse(valStr));
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.WriteLine($"{nameof(RemoveElement)}: {result}");

    foreach (var num in nums) 
        Console.Write(num + " ");


    Console.WriteLine();
}

int RemoveElement(int[] nums, int val)
{
    var result = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != val)
        {
            if (result != i) 
                nums[result] = nums[i];

            result++;
        }
        else if (result < nums.Length - 1 && nums[result] == val)
        {
            var ind = result + 1;

            while (ind < nums.Length && nums[ind] == val)
            {
                ind++;
            }

            if (ind >= nums.Length) continue;

            nums[result] = nums[ind];
            nums[ind] = val;
            i = ind - 1;
            result++;
        }
    }

    return result;
}
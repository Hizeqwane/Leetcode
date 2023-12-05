// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = FirstMissingPositive(nums);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(FirstMissingPositive)}: {result}");
    
    Console.WriteLine();
}


int FirstMissingPositive(int[] nums)
{
    int n = nums.Length;
    int upperBound = nums.Max();

    if (upperBound < 1)
        return 1;

    upperBound = Math.Min(upperBound, n);

    for (int i = 0; i < n; i++)
    {
        if (nums[i] < 1 || nums[i] > upperBound)
        {
            nums[i] = Int32.MaxValue;
        }
    }


    int val = 0;
    for (int i = 0; i < n; i++)
    {
        val = Math.Abs(nums[i]);
        if (val <= upperBound)
        {
            nums[val - 1] = -Math.Abs(nums[val - 1]);
        }
    }

    for (int i = 0; i < upperBound; i++)
    {
        if (nums[i] > 0)
        {
            return i + 1;
        }
    }

    return upperBound + 1;
}

int FirstMissingPositiveMy(int[] nums)
{
    var missingLowest = 1;

    var hash = new HashSet<int>();

    foreach (var num in nums)
    {
        if (num == missingLowest)
        {
            do
            {
                missingLowest++;
            } while (hash.TryGetValue(missingLowest, out _));
        }

        hash.Add(num);
    }

    return missingLowest;
}

// 2 4 3 1 5
// 
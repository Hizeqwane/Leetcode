while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = CanJump(nums);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(CanJump)}: {result}");
    
    Console.WriteLine();
}

bool CanJump(int[] nums)
{
    var n = nums.Length;
    var max = 0;
    for (var i = 0; i < n - 1; i++)
    {
        if (max >= i + nums[i] && i == max)
            return false;

        max = Math.Max(max, nums[i] + i);
    }
    return true;
}
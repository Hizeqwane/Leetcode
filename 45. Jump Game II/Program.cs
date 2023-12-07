while (true)
{
    string date = "29.05.83";
    var d = DateTime.Parse(date);
    var t = DateTime.TryParse(date, out _);

    Console.WriteLine("Введите массив через запятую.");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = Jump(nums);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(Jump)}: {result}");
    
    Console.WriteLine();
}

int Jump(int[] nums)
{
    int n = nums.Length;
    int prevMax = 0;
    int max = 0;
    int steps = 0;
    for (int i = 0; i < n - 1; i++)
    {
        max = Math.Max(max, i + nums[i]);
        if (i == prevMax)
        {
            steps++;
            prevMax = max;
        }
    }
    return steps;
}

int JumpMy(int[] nums)
{
    return GetBest(nums, 0);
}

int GetBest(int[] nums, int startInd)
{
    if (startInd == nums.Length - 1) 
        return 0;
    if (nums[startInd] >= nums.Length - startInd - 1)
        return 1;

    var endForFinding = Math.Min(nums.Length - 1, startInd + nums[startInd]);

    var maxStep = 0;
    var indMax = 0;
    for (int i = startInd + 1; i <= endForFinding; i++)
    {
        var currentAvailableStep = nums[i] + (i - startInd - 1);
        if (currentAvailableStep > maxStep)
        {
            maxStep = currentAvailableStep;
            indMax = i;
        }
    }

    return 1 + GetBest(nums, indMax);
}
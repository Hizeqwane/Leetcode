using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите массив через запятую");
    var nums = Console.ReadLine().Split(",").Select(s => int.Parse(s)).ToArray();

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var result = Permute(nums);
    stopWatch.Stop();

    Console.WriteLine("Permute: Время выполнения: {0}", stopWatch.Elapsed);
    foreach (var res in result) 
        Console.WriteLine(string.Join(" , ", res));

    Console.WriteLine();

    stopWatch.Restart();
    result = PermuteMy(nums);
    stopWatch.Stop();

    Console.WriteLine("MyPermute: Время выполнения: {0}", stopWatch.Elapsed);
    foreach (var res in result)
        Console.WriteLine(string.Join(" , ", res));
}

IList<IList<int>> Permute(int[] nums)
{
    var result = new List<IList<int>>();
    var visited = new bool[nums.Length];
    BackTrack(nums, new List<int>(), visited, result);
    return result;
}

void BackTrack(int[] nums, List<int> current, bool[] visited, IList<IList<int>> result)
{
    if (current.Count == nums.Length)
    {
        result.Add(new List<int>(current));
        return;
    }

    for (int i = 0; i < nums.Length; i++)
    {
        if (visited[i]) { continue;}

        visited[i] = true;
        current.Add(nums[i]);
        BackTrack(nums, current, visited, result);
        current.Remove(nums[i]);
        visited[i] = false;
    }
}



#region Cheat with using Task №31
IList<IList<int>> PermuteMy(int[] nums)
{
    if (nums.Length == 1)
        return new List<IList<int>> { nums.ToList() };

    var hash = new HashSet<string>();
    while (hash.Add(string.Join(',', nums)))
    {
        NextPermutation(nums);
    }

    var result = new List<IList<int>>();
    foreach (var h in hash)
        result.Add(h.Split(',').Select(int.Parse).ToList());

    return result;
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
#endregion
using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите массив через запятую");
    var nums = Console.ReadLine().Split(",").Select(s => int.Parse(s)).ToArray();

    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var result = PermuteUnique(nums);
    stopWatch.Stop();

    Console.WriteLine("PermuteUnique: Время выполнения: {0}", stopWatch.Elapsed);
    foreach (var res in result) 
        Console.WriteLine(string.Join(" , ", res));

    Console.WriteLine();
}

IList<IList<int>> PermuteUnique(int[] nums)
{
    var result = new List<IList<int>>();
    var visited = new bool[nums.Length];
    var hash = new HashSet<string>();
    BackTrack(nums, new List<int>(), visited, result, hash);
    return result;
}

void BackTrack(int[] nums, List<int> current, bool[] visited, IList<IList<int>> result, HashSet<string> hashSet)
{
    if (current.Count == nums.Length)
    {
        //if (hashSet.Add(string.Join(',', current))) 
            result.Add(new List<int>(current));

        return;
    }

    for (int i = 0; i < nums.Length; i++)
    {
        if (visited[i]) { continue;}

        visited[i] = true;
        current.Add(nums[i]);
        BackTrack(nums, current, visited, result, hashSet);
        current.RemoveAt(current.Count - 1);
        visited[i] = false;
    }
}
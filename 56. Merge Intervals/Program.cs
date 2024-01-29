while (true)
{
    Console.WriteLine("Введите массивы (все числа через запятую).");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine();

    var intervals = new int[nums.Length / 2][];
    for (int i = 0; i < nums.Length; i++)
    {
        intervals[i / 2] ??= new int[2];
        if (i % 2 == 0)
            intervals[i / 2][0] = nums[i];
        else
            intervals[i / 2][1] = nums[i];
    }

    var d1 = DateTime.Now;
    var result = Merge(intervals);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(Merge)}: {result}");

    Console.WriteLine();
}

int[][] Merge(int[][] intervals)
{
    var result = new List<int[]>();

    foreach (var interval in intervals)
    {
        var start = interval[0];
        var end = interval[1];

        var wasFounded = false;
        foreach (var resInterval in result)
        {
            var resStart = resInterval[0];
            var resEnd = resInterval[1];

            if (start > resStart && end < resEnd)
            {
                wasFounded = true;
                break;
            }

            if (start > resStart && end > resEnd)
            {
                resInterval[1] = end;

                wasFounded = true;
                break;
            }

            if (start < resStart && end < resEnd)
            {
                resInterval[0] = start;

                wasFounded = true;
                break;
            }

            if (start < resStart && end > resEnd)
            {
                resInterval[0] = start;
                resInterval[1] = end;

                wasFounded = true;
                break;
            }
        }

        if (!wasFounded)
        {
            result.Add(new []{start, end});
        }
    }

    return result.ToArray();
}
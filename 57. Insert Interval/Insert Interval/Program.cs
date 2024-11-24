using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите массив через точку с запятой между массивами и запятой между числами.");
    var intervals = Console.ReadLine()!.GetAllArrays();
    
    Console.WriteLine("Введите массив через запятую.");
    var newInterval = Console.ReadLine()!.GetArray();

    Console.WriteLine();

    var watch = new Stopwatch();
    watch.Start();
    var result = Insert(intervals, newInterval);
    watch.Stop();
    var t = watch.Elapsed;

    Console.WriteLine("Время выполнения: {0}", t);
    Console.Write($"{nameof(Insert)}: [{string.Join("], [", result.Select(s => string.Join(',', s)))}]");
    
    Console.WriteLine();
}

int[][] Insert(int[][] intervals, int[] newInterval)
{
    var result = new List<int[]>();

    if (intervals.Length == 0)
    {
        result.Add(newInterval);

        return result.ToArray();
    }
    
    for (var i = 0; i < intervals.Length; i++)
    {
        if (newInterval[0] > intervals[i][1])
        {
            result.Add([intervals[i][0], intervals[i][1]]);
            
            if (i == intervals.Length - 1)
                result.Add(newInterval);
            
            continue;
        }

        if (newInterval[1] < intervals[i][0])
        {
            result.Add([newInterval[0], newInterval[1]]);
            for (var j = i; j < intervals.Length; j++) 
                result.Add([intervals[j][0], intervals[j][1]]);
            
            break;
        }
        
        var newMinLine = Math.Min(newInterval[0], intervals[i][0]);

        
        //i++;
        while (i < intervals.Length)
        {
            if (newInterval[1] >= intervals[i][0] &&
                newInterval[1] <= intervals[i][1])
                break;

            if (newInterval[1] < intervals[i][0])
            {
                i--;
                break;
            }
            
            i++;
        }

        var newMaxLine = i < intervals.Length
            ? Math.Max(newInterval[1], intervals[i][1])
            : newInterval[1];

        result.Add([newMinLine, newMaxLine]);
        for (var j = i + 1; j < intervals.Length; j++) 
            result.Add([intervals[j][0], intervals[j][1]]);
            
        break;
    }

    return result.ToArray();
}

int[][] BetterInsert(int[][] intervals, int[] newInterval) {
    List<int[]> result = new List<int[]>();
        
    // Iterate through intervals and add non-overlapping intervals before newInterval
    int i = 0;
    while (i < intervals.Length && intervals[i][1] < newInterval[0]) {
        result.Add(intervals[i]);
        i++;
    }
        
    // Merge overlapping intervals
    while (i < intervals.Length && intervals[i][0] <= newInterval[1]) {
        newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
        newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
        i++;
    }
        
    // Add merged newInterval
    result.Add(newInterval);
        
    // Add non-overlapping intervals after newInterval
    while (i < intervals.Length) {
        result.Add(intervals[i]);
        i++;
    }
        
    return result.ToArray();
}

public static class Ext
{
    public static int[][] GetAllArrays(this string str) =>
        str
            .Trim('[', ']')
            .Split(';')
            .Select(GetArray)
            .ToArray();
    
    public static int[] GetArray(this string str)
    {
        var strArray = str
            .Trim('[', ']')
            .Split(',');
        
        return [int.TryParse(strArray[0], out var int0) ? int0 : 0, int.TryParse(strArray[1], out var int1) ? int1 : 0];
    }
}
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Введите массив чисел через запятую (,).");
var numsStr = Console.ReadLine();
var numsStrArray = numsStr.Split(',');
var nums = new int[numsStrArray.Length];
for (int i = 0; i < numsStrArray.Length; i++)
    nums[i] = int.Parse(numsStrArray[i]);

Console.WriteLine("Введите число для нахождения twoSum.");
var targetStr = Console.ReadLine();
var target = int.Parse(targetStr);

var result = TwoSum(nums, target);
Console.WriteLine("Найденные индексы twoSum: " + result[0] + ' ' + result[1]);
Console.Read();

int[] TwoSum(int[] nums, int target)
{
    var addDict = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        var isSolution = addDict.TryGetValue(nums[i], out var resIndex);

        if (isSolution)
            return new[]
            {
                resIndex,
                i
            };

        addDict.TryAdd(target - nums[i], i);
    }

    throw new Exception();
}

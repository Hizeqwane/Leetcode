// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = Trap(nums);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(Trap)}: {result}");
    
    Console.WriteLine();
}

int Trap(int[] height)
{
    var n = height.Length;
    var tmpSum = 0;
    var maxL = 0;
    var maxR = 0;
    for (int i = 0; i < n; i++)
    {
        var currentL = height[i];
        var currentR = height[n - i - 1];

        maxL = Math.Max(currentL, maxL);
        maxR = Math.Max(currentR, maxR);
        tmpSum += maxL + maxR - currentL;
    }

    return tmpSum - maxL * n;
}

int TrapMy(int[] height)
{
    var trapDict = new Dictionary<int, int>();

    var trap = 0;
    var currentMax = height[0];
    var currentMaxInd = 0;

    for (int i = 1; i < height.Length; i++)
    {
        if (height[i] > height[i - 1])
        {
            for (int j = i - 1; j > currentMaxInd; j--)
            {
                var val = Math.Min(height[i], currentMax) - height[j];
                if (val <= 0)
                    break;

                trapDict[j] = val;
            }

        }

        if (height[i] > currentMax)
        {
            currentMax = height[i];
            currentMaxInd = i;
        }
    }

    return trapDict.Sum(s => s.Value);
}

// 4 2 3
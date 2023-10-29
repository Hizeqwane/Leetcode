// See https://aka.ms/new-console-template for more information
while (true)
{
    Console.WriteLine("Введите массив 1 чисел через запятую (,).");
    var numsStr = Console.ReadLine();
    var numsStrArray = numsStr.Split(',');
    int[] nums1;
    if (numsStrArray is [""])
        nums1 = Array.Empty<int>();
    else
    {
        nums1 = new int[numsStrArray.Length];
        for (int i = 0; i < numsStrArray.Length; i++)
            nums1[i] = int.Parse(numsStrArray[i]);
    }

    Console.WriteLine("Введите массив 2 чисел через запятую (,).");
    numsStr = Console.ReadLine();
    numsStrArray = numsStr.Split(',');
    int[] nums2;
    if (numsStrArray is [""])
        nums2 = Array.Empty<int>();
    else
    {
        nums2 = new int[numsStrArray.Length];
        for (int i = 0; i < numsStrArray.Length; i++)
            nums2[i] = int.Parse(numsStrArray[i]);
    }

    var result = MedianOfTwoSortedArrays(nums1, nums2);
    Console.WriteLine($"Результат = {result}");
}
double MedianOfTwoSortedArrays(int[] nums1, int[] nums2)
{
    int n = nums1.Length;
    int m = nums2.Length;

    if (m == 0 && n == 0)
        return 0;

    int[] maxNums;
    int[] minNums;
    int min;

    if (n > m)
    {
        maxNums = nums1;
        minNums = nums2;
        min = m;
    }
    else
    {
        maxNums = nums2;
        minNums = nums1;
        min = n;
    }

    if (min == 0)
    {
        if (maxNums.Length % 2 == 0)
        {
            var middle = maxNums.Length / 2;
            return (maxNums[middle] + maxNums[middle - 1]) / 2.0;
        }

        return maxNums[(int)Math.Floor(maxNums.Length / 2.0)];
    }

    var countOfLastChoice = (int)Math.Floor((n + m) / 2.0) + 1;
    var startInd = n == m ? countOfLastChoice - 2 : countOfLastChoice - 1;

    int indForMax = startInd;
    int indForMin = min - 1;
    while (indForMax >= 0)
    {
        if (indForMin + indForMax + 2 == countOfLastChoice)
        {
            int[] m1;
            int[] m2;
            int indM1;
            int indM2;

            if (indForMin < 0 || maxNums[indForMax] > minNums[indForMin])
            {
                m1 = maxNums;
                m2 = minNums;
                indM1 = indForMax;
                indM2 = indForMin;
            }
            else
            {
                m1 = minNums;
                m2 = maxNums;
                indM1 = indForMin;
                indM2 = indForMax;
            }

            if ((n + m) % 2 == 0)
                return indM1 == 0
                    ? (m1[indM1] + m2[indM2]) / 2.0
                    : (
                            m1[indM1] + 
                            (
                                indM2 < 0 || m1[indM1 - 1] > m2[indM2]
                                    ? m1[indM1 - 1]
                                    : m2[indM2]
                            )
                      ) / 2.0;
            
            return m1[indM1];
        }


        if (maxNums[indForMax] > minNums[indForMin])
            indForMax--;
        else
            indForMin--;
    }

    throw new Exception("Фуфло а не алгоритм");
}
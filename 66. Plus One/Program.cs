using System.Diagnostics;

while (true)
{
    Console.WriteLine("Введите цифры");
    var digits = Console.ReadLine().Split(";").Select(int.Parse).ToArray();
    
    var stopWatch = Stopwatch.StartNew();
    var result = PlusOne(digits);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(PlusOne)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine("[" + string.Join(", ", result) + "]");

    Console.WriteLine();
}

int[] PlusOne(int[] digits)
{
    // var result = new List<int>(digits.Length + 1);
    //
    // var isAboveTen = false;
    // for (var i = digits.Length - 1; i >= 0; i--)
    // {
    //     if (i == digits.Length - 1 || isAboveTen)
    //     {
    //         if (digits[i] == 9)
    //         {
    //             isAboveTen = true;
    //             result.Add(0);
    //             continue;
    //         }
    //         
    //         result.Add(digits[i] + 1);
    //         isAboveTen = false;
    //         continue;
    //     }
    //     
    //     result.Add(digits[i]);
    // }
    //
    // if (isAboveTen)
    //     result.Add(1);
    //
    // result.Reverse();
    // return result.ToArray();
    
    for(var i = digits.Length - 1; i >= 0 ; i--)
    {
        digits[i] += 1;
        if(digits[i] != 10) 
            return digits;
        
        digits[i] = 0;            
    }
    
    var newArray = new int[digits.Length + 1];
    newArray[0] = 1;
    
    return newArray;
}
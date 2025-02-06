using System.Diagnostics;
using System.Text;

while (true)
{
    Console.WriteLine("Введите числа n и k через запятую");
    var split = Console.ReadLine().Split(',');
    var n = int.Parse(split[0]);
    var k = int.Parse(split[1]);
    
    var stopWatch = Stopwatch.StartNew();
    var result = GetPermutation(n, k);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(GetPermutation)}: Время выполнения: {stopWatch.Elapsed}");

    Console.WriteLine(result);

    Console.WriteLine();
}

string GetPermutation(int n, int k)
{
    if (n == 1)
        return n.ToString();
    
    var result = new StringBuilder();

    var facts = new List<int>(n);
    var numbers = new List<int>(n);

    for (var i = 1; i <= n; i++)
    {
        facts.Add(i <= 2
            ? 1
            : (i - 1) * facts[i - 2]);
        numbers.Add(i);
    }

    var currentK = k;

    while (numbers.Count > 0)
    {
        var fact = facts[numbers.Count - 1];
        
        var ind = numbers.Count == 1
            ? 0
            : (currentK - 1) / fact;
        
        result.Append(numbers[ind]);
        
        numbers.RemoveAt(ind);
        
        currentK -= ind * fact;
    }

    return result.ToString();
}
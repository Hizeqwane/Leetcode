Console.WriteLine("Введите число");
var num = int.Parse(Console.ReadLine());



// Загадывается число (в классической версии 4-значное).
// Пытаемся угадать:
// 1. Если цифра из предполагаемого числа присутствует в загаданном числе И совпадает по местоположению - это "бык".
// 2. Если цифра из предполагаемого числа присутствует в загаданном числе, но на другом месте - это "корова".

IList<BullsAndCowsRow> GetSolution(int num)
{
    var resolver = new BullsAndCowsResolver(num);

    var n = num.ToString().Length;
    var numbers = "1234567890";

    var cows = new int[n];
    var bulls = new int[n];

    var solution = new List<BullsAndCowsRow>();

    var prime = int.Parse(numbers.Substring(0, n));
    var currentSol = resolver.Resolve(prime);
    solution.Add(currentSol);

    while (currentSol.Bulls != n)
    {
        if (currentSol.Bulls > 0)
        {

        }
    }

    return solution;
}

// 3190
// 3572 - 1б
// 1234 - 2к

public class BullsAndCowsTreatmenter
{
    public BullsAndCowsTreatmenter()
    {
        
    }
}
class BullsAndCowsResolver
{
    public int Value { get; }
    private readonly string _valueStr;

    public BullsAndCowsResolver(int value)
    {
        Value = value;
        _valueStr = value.ToString();
    }

    public BullsAndCowsRow Resolve(string value) => Resolve(int.Parse(value));

    public BullsAndCowsRow Resolve(int num)
    {
        var bulls = 0;
        var cows = 0;

        var numStr = num.ToString();
        for (int i = 0;  i < numStr.Length; i++)
        {
            if (numStr[i] == _valueStr[i])
            {
                bulls++; 
                continue;
            }

            if (_valueStr.Contains(numStr[i]))
            {
                cows++;
            }
        }

        return new BullsAndCowsRow(num, bulls, cows);
    }
}
record BullsAndCowsRow(int qValue, int Bulls, int Cows);
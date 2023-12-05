// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var candidates = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine("Введите target.");
    var target = int.Parse(Console.ReadLine());

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = CombinationSum(candidates, target);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(CombinationSum)}: ");
    foreach (var list in result)
    {

        foreach (var el in list)
        {
            Console.Write(el + " , ");
        }

        Console.WriteLine();
    }
    
    Console.WriteLine();
}

IList<IList<int>> CombinationSum(int[] candidates, int target)
{
    var result = new List<IList<int>>();
    Search(candidates, target, 0, 0, new List<int>(), result);
    return result;
}

IList<IList<int>> CombinationSumMy(int[] candidates, int target)
{
    Array.Sort(candidates);

    if (candidates[0] > target)
        return new List<IList<int>>();

    var result = new List<IList<int>>();

    var state = new Dictionary<int, int>
    (
        candidates.Select(s => new KeyValuePair<int, int>(s, 0))
    );

    var currentInd = candidates.Length - 1;

    while (currentInd >= 0)
    {
        
        while (GetSum(state) < target)
        {
            state[candidates[currentInd]]++;
        }

        if (GetSum(state) == target) 
            result.Add(GetListFromState(state));

        state[candidates[currentInd]]--;
        currentInd--;

        if (currentInd == -1)
        {
            currentInd = GetMinNot0CountAndBiggerThan0Ind(candidates, state);
            state[candidates[0]] = 0;
            state[candidates[currentInd]]--;
            currentInd--;
        }
    }

    return result;
}

int GetSum(Dictionary<int, int> state) => state.Sum(number => number.Key * number.Value);

List<int> GetListFromState(Dictionary<int, int> state)
{
    var result = new List<int>();
    foreach (var number in state)
        for (int i = 0; i < number.Value; i++)
            result.Add(number.Key);

    return result;
}

int GetMinNot0CountAndBiggerThan0Ind(int[] candidates, Dictionary<int, int> state)
{
    for (int i = 1; i < candidates.Length; i++)
        if (state[candidates[i]] > 0)
            return i;

    return 0;
}
void Search(int[] candidates, int target, int index, int sum, IList<int> temp, IList<IList<int>> result)
{
    candidates = candidates.OrderByDescending(s => s).ToArray();

    if (sum == target)
    {
        result.Add(temp.ToArray());
        return;
    }

    while (sum < target && index < candidates.Length)
    {
        temp.Add(candidates[index]);

        Search(candidates, target, index, sum + candidates[index], temp, result);

        temp.RemoveAt(temp.Count - 1);
        index++;
    }
}
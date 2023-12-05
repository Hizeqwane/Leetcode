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
    var result = CombinationSum2(candidates, target);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(CombinationSum2)}: ");
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



IList<IList<int>> CombinationSum2(int[] candidates, int target)
{
    var result = new List<IList<int>>();
    if (candidates.Sum() < target)
        return result;
    Array.Sort(candidates);
    Search(candidates, target, new List<int>(), 0, result);
    return result;
}
void Search(int[] candidates, int target, IList<int> temp, int index, IList<IList<int>> result)
{
    if (target == 0)
    {
        int[] curr = new int[temp.Count];
        temp.CopyTo(curr, 0);
        result.Add(curr);
        return;
    }
    if (target < 0 || index >= candidates.Length)
    {
        return;
    }
    temp.Add(candidates[index]);
    Search(candidates, target - candidates[index], temp, index + 1, result);
    temp.Remove(candidates[index]);
    while (index + 1 < candidates.Length && candidates[index] == candidates[index + 1])
    {
        index++; 
    }
    Search(candidates, target, temp, index + 1, result);
}
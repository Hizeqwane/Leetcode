// See https://aka.ms/new-console-template for more information

while (true)
{
    Console.WriteLine("Введите сортированный массив через запятую.");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine("Введите target.");
    var target = int.Parse(Console.ReadLine());

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = SearchRange(nums, target);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(SearchRange)}: {result}");
    
    Console.WriteLine();
}

int[] SearchRange(int[] nums, int target)
{
    var a = Array.FindIndex(nums, s => s < target);

    return new[] { Array.IndexOf(nums, target), Array.LastIndexOf(nums, target) };
}
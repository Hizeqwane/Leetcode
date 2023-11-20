// See https://aka.ms/new-console-template for more information

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

    Console.WriteLine("Введите target.");
    var target = int.Parse(Console.ReadLine());

    Console.WriteLine();
    
    var d1 = DateTime.Now;
    var result = Search(nums, target);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(Search)}: {result}");
    
    Console.WriteLine();
}

int Search(int[] nums, int target)
{
    return Array.IndexOf(nums, target);
}
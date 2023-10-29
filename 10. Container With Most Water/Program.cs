// See https://aka.ms/new-console-template for more information

using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var str = Console.ReadLine();

    var result = MaxArea(str.Split(',').Select(s => int.Parse(s)).ToArray());
    Console.WriteLine($"IsMatch: {result}");
}

int MaxArea(int[] height)
{
    int si = 0;
    int ei = height.Length;


}

int FindVolume(int[] height, int si, int ei) =>
    (ei - si) * Math.Max(height[si], height[ei]);
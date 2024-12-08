using System.Diagnostics;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую");
    var nodes = Console.ReadLine().Split(',').Select(s => new ListNode(int.Parse(s))).ToList();
    
    Console.WriteLine("Введите k");
    var k = int.Parse(Console.ReadLine());

    for (var i = 0; i < nodes.Count - 1; i++) 
        nodes[i].next = nodes[i + 1];
    
    var stopWatch = Stopwatch.StartNew();
    var result = RotateRight(nodes.FirstOrDefault(), k);
    stopWatch.Stop();

    Console.WriteLine();
    Console.WriteLine($"{nameof(RotateRight)}: Время выполнения: {stopWatch.Elapsed}");

    var node = result;

    while (node != null)
    {
        Console.WriteLine(node.val);
        node = node.next;
    }

    Console.WriteLine();
}

ListNode RotateRight(ListNode head, int k)
{
    var list = new List<ListNode>();

    var node = head;
    while (node != null)
    {
        list.Add(node);
        node = node.next;
    }

    if (list.Count == 0)
        return null;

    var rotation = k % list.Count;

    if (rotation == 0)
        return head;

    list[^(rotation + 1)].next = null;
    list.Last().next = list.First();
    
    return list[^(rotation)];
}

public class ListNode {
  public int val;
  public ListNode next;
  public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
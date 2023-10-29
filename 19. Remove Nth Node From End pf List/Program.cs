// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var numsStr = Console.ReadLine();

    Console.WriteLine("Введите n.");
    var n = int.Parse(Console.ReadLine());

    Console.WriteLine();

    var nums = numsStr.Split(',').Select(s => int.Parse(s)).ToArray();

    var nodeList = new List<ListNode>();

    for (int i = 0; i < nums.Length; i++)
    {
        var newListNode = new ListNode(nums[i]);
        if (i > 0)
            nodeList[i - 1].next = newListNode;
        nodeList.Add(newListNode);
    }

    var d1 = DateTime.Now;
    var result = RemoveNthFromEnd(nodeList[0], n);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(RemoveNthFromEnd)}: ");
    Console.Write(result?.val);
    while (result?.next != null)
    {
        result = result.next;
        Console.Write(", " + result.val);
    }

    Console.WriteLine();
}

ListNode RemoveNthFromEnd(ListNode head, int n)
{
    if (head.next == null)
        return null;

    ListNode prevToDel = new ListNode(0, head);
    var current = head;
    while (n > 1)
    {
        current = current.next;
        n--;
    }

    while (current.next != null)
    {
        prevToDel = prevToDel == null ? head : prevToDel.next;
        current = current.next;
    }

    prevToDel.next = prevToDel.next.next;

    return head;
}

class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
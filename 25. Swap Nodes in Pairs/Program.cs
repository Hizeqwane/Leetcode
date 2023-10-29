// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массив через запятую.");
    var numsStr = Console.ReadLine();

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
    //var result = SwapNodesInPairs(nodeList[0]);
    var result = SwapPairs(nodeList[0]);
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(SwapNodesInPairs)}: ");
    Console.Write(result?.val);
    while (result?.next != null)
    {
        result = result.next;
        Console.Write(", " + result.val);
    }

    Console.WriteLine();
}

ListNode SwapNodesInPairs(ListNode head)
{
    if (head.next == null)
        return head;

    var current = head;
    var prevBegin = new ListNode(0, head);
    var prev = prevBegin;
    while (current != null)
    {
        var s = current.next;
        if (s == null)
            break;

        var t = s.next;

        prev.next = s;
        s.next = current;
        current.next = t;

        prev = current;
        current = t;
    }

    return prevBegin.next;
}

ListNode SwapPairs(ListNode head)
{
    if (head == null)
        return null;

    if (head.next == null)
        return head;

    return CheckPairs(head, 1);
}

static ListNode CheckPairs(ListNode node, int index)
{
    index++;
    if (node != null)
    {
        ListNode result = CheckPairs(node.next, index);
        node.next = result;

        if ((index % 2 == 0) && (result != null))
        {
            ListNode next = result.next;
            result.next = node;
            node.next = next;
        }
        else
            result = node;

        return result;
    }
    else
        return node;
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
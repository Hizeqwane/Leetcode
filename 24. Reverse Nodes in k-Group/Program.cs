// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

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

    Console.WriteLine("Введите k.");
    var k = Console.ReadLine();

    var d1 = DateTime.Now;
    var result = ReverseKGroup(nodeList[0], int.Parse(k));
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(ReverseKGroup)}: ");
    Console.Write(result?.val);
    while (result?.next != null)
    {
        result = result.next;
        Console.Write(", " + result.val);
    }

    Console.WriteLine();
}

ListNode ReverseKGroup(ListNode head, int k)
{
    if (head.next == null)
        return head;

    return CheckK(head, new ListNode(0, head), k);
}

static ListNode CheckK(ListNode head, ListNode prevNode, int k)
{
    var end = prevNode.next;
    var nextHead = prevNode;
    var count = 0;
    while (count < k)
    {
        nextHead = nextHead.next;
        if (nextHead == null)
            return head;
        
        count++;
    }

    if (prevNode.next == head)
        head = ReverseFirstK(prevNode.next, k);
    else
        prevNode.next = ReverseFirstK(prevNode.next, k);

    return CheckK(head, end, k);
}

static ListNode ReverseFirstK(ListNode head, int k)
{
    var endSwap = k;
    for (int j = 1; j < k; j++)
    {
        for (int i = 1; i < endSwap; i++)
        {
            head = SwapTwo(head, i);
        }

        endSwap--;
    }

    return head;
}

static ListNode SwapTwo(ListNode head, int pos)
{
    var prev = new ListNode(0, head);
    var node = head;
    var ind = 1;
    while (ind < pos)
    {
        prev = node;
        node = node.next;
        ind++;
    }

    var second = node.next;
    var third = node.next.next;
    node.next = third;
    second.next = node;
    prev.next = second;

    return pos == 1 ? second : head;
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
// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массив 1 через запятую.");
    var numsStr1 = Console.ReadLine();

    Console.WriteLine("Введите массив 2 через запятую.");
    var numsStr2 = Console.ReadLine();

    Console.WriteLine();

    var nums1 = numsStr1.Length > 0 ? numsStr1.Split(',').Select(s => int.Parse(s)).ToArray() : new int[0];
    var nums2 = numsStr2.Length > 0 ? numsStr2.Split(',').Select(s => int.Parse(s)).ToArray() : new int[0];

    var nodeList1 = new List<ListNode>();

    for (int i = 0; i < nums1.Length; i++)
    {
        var newListNode = new ListNode(nums1[i]);
        if (i > 0)
            nodeList1[i - 1].next = newListNode;
        nodeList1.Add(newListNode);
    }

    var nodeList2 = new List<ListNode>();

    for (int i = 0; i < nums2.Length; i++)
    {
        var newListNode = new ListNode(nums2[i]);
        if (i > 0)
            nodeList2[i - 1].next = newListNode;
        nodeList2.Add(newListNode);
    }

    var d1 = DateTime.Now;
    var result = MergeTwoLists(nodeList1.FirstOrDefault(), nodeList2.FirstOrDefault());
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(MergeTwoLists)}: ");
    Console.Write(result?.val);
    while (result?.next != null)
    {
        result = result.next;
        Console.Write(", " + result.val);
    }

    Console.WriteLine();
}

ListNode MergeTwoLists(ListNode list1, ListNode list2)
{
    ListNode dummyHead = new ListNode(-1);
    // Create a dummy node as the starting point
    ListNode current = dummyHead;
    // Pointer to keep track of the current node

    while (list1 != null && list2 != null)
    {
        if (list1.val <= list2.val)
        {
            current.next = list1;
            list1 = list1.next;
        }
        else
        {
            current.next = list2;
            list2 = list2.next;
        }
        current = current.next;
    }

    // Attach the remaining nodes if any
    if (list1 != null)
    {
        current.next = list1;
    }
    else
    {
        current.next = list2;
    }

    return dummyHead.next;
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
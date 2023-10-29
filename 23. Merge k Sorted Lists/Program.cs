// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.WriteLine("Введите массивы через запятую, отделяя их друг от друга ; .");
    var numsStr = Console.ReadLine();

    Console.WriteLine();

    var numsList = numsStr.Length > 0 
        ? numsStr.Split(';').Where(s => s.Length > 0).ToList() 
        : null;

    var nums = numsList.Count > 0
        ? numsList.Select(s => s.Split(',').Select(s => int.Parse(s)).ToList()).ToList()
        : null;

    var nodeListsList = new List<List<ListNode>>();

    for (int i = 0; i < nums.Count; i++)
    {
        nodeListsList.Add(new List<ListNode>());

        for (int j = 0; j < nums[i].Count(); j++)
        {
            var newListNode = new ListNode(nums[i][j]);
            if (j > 0)
                nodeListsList[i][j - 1].next = newListNode;
            nodeListsList[i].Add(newListNode);
        }
    }

    var d1 = DateTime.Now;
    var result = MergeKLists(nodeListsList.Select(s => s.FirstOrDefault()).ToArray());
    var d2 = DateTime.Now;

    Console.WriteLine("Время выполнения: {0}", d2 - d1);
    Console.Write($"{nameof(MergeKLists)}: ");
    Console.Write(result?.val);
    while (result?.next != null)
    {
        result = result.next;
        Console.Write(", " + result.val);
    }

    Console.WriteLine();
}

ListNode MergeKLists(ListNode[] lists)
{
    if (lists.Length == 0)
        return null;

    ListNode dummyHead = new ListNode(-1);
    // Create a dummy node as the starting point
    ListNode current = dummyHead;
    // Pointer to keep track of the current node

    var listsList = lists.Where(s => s != null).ToList();

    while (listsList.Count > 0)
    {
        var min = FindMinNode(listsList);
        current.next = listsList[min];
        listsList[min] = listsList[min].next;
        if (listsList[min] == null)
            listsList.Remove(listsList[min]);
        current = current.next;
    }

    return dummyHead.next;
}

int FindMinNode(List<ListNode> lists)
{
    var min = 0;
    int i = 1;
    while (i < lists.Count && lists[min].val != -10000)
    {
        if (lists[i].val < lists[min].val)
            min = i;
        i++;
    }
    return min;
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
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Введите ListNode1 через запятую (,).");
var numsStr1 = Console.ReadLine();
var numsStrArray1 = numsStr1.Split(',');
var listNode1 = new ListNodeList(numsStrArray1);

Console.WriteLine("Введите ListNode2 через запятую (,).");
var numsStr2 = Console.ReadLine();
var numsStrArray2 = numsStr2.Split(',');
var listNode2 = new ListNodeList(numsStrArray2);

var result = AddTwoNumbers(listNode1.ListNodes.First(), listNode2.ListNodes.First());

Console.Write(result.val);
while (result.next != null)
{
    Console.Write(", " + result.next.val);
    result = result.next;
}

Console.Read();

ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    var resultNode = new ListNode();

    var resNode = resultNode;
    var node1 = l1;
    var node2 = l2;
    var isNeedAdd1 = false;

    while (node1 != null || node2 != null)
    {
        resNode.next = new ListNode(isNeedAdd1 ? 1 : 0);
        resNode = resNode.next;
        var val1 = node1?.val ?? 0;
        var val2 = node2?.val ?? 0;
        var sum = val1 + val2;

        isNeedAdd1 = false;
        if (sum >= 10)
        {
            sum -= 10;
            isNeedAdd1 = true;
        } else if (sum == 9 && resNode.val == 1)
        {
            sum = -1;
            isNeedAdd1 = true;
        }

        resNode.val += sum;

        node1 = node1?.next;
        node2 = node2?.next;
    }
    if (isNeedAdd1)
        resNode.next = new ListNode(1);

    return resultNode.next;
}

class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int value=0, ListNode nextNode = null)
    {
        val = value;
        next = nextNode;
    }
}

class ListNodeList
{
    public List<ListNode> ListNodes { get; set; }

    public ListNodeList(string[] nums)
    {
        ListNodes = new();

        for (int i = 0; i < nums.Length; i++)
        {
            var newListNode = new ListNode(int.Parse(nums[i]));
            ListNodes.Add(newListNode);

            if (i > 0)
                ListNodes[i - 1].next = newListNode;
        }
    }
}
using System.Diagnostics;

var stopWatch = Stopwatch.StartNew();

var _1 = new ListNode(3);
var _2 = new ListNode(2);
var _3 = new ListNode(0);
var _4 = new ListNode(-4);

_1.next = _2;
_2.next = _3;
_3.next = _4;
_4.next = _2;

var result = DetectCycle(_1);
stopWatch.Stop();

Console.WriteLine();
Console.WriteLine($"{nameof(DetectCycle)}: Время выполнения: {stopWatch.Elapsed}");

Console.WriteLine();   

ListNode DetectCycle(ListNode head)
{
    ListNode small = head;
    ListNode big = head;

    do
    {
        small = small?.next;
        big = big?.next?.next;

        if (small == null || big == null)
            return null;

    } while (small.val != big.val);

    big = head;
    
    do
    {
        if (small.val == big.val)
            return big;

        small = small.next;
        big = big.next;

    } while (true);
}

class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {
        val = x;
        next = null;
    }
}
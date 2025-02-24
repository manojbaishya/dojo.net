namespace Dojo.Net.Leetcode;

public class ListNode(int val = 0, ListNode? next = null)
{
    public int Val = val;
    public ListNode? Next = next;
}

public class AddTwoNumbersSolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var carryover = 0;
        ListNode sumNode = new();
        ListNode head = sumNode;
        ListNode? lm1 = l1;
        ListNode? lm2 = l2;
        while (lm1 != null || lm2 != null)
        {
            int sum = 0;
            if (lm1 != null && lm2 != null)
                sum = lm1.Val + lm2.Val + carryover;
            else if (lm1 == null && lm2 != null)
                sum = lm2.Val + carryover;
            else if (lm1 != null && lm2 == null)
                sum = lm1.Val + carryover;

            if (sum > 9)
            {
                carryover = 1;
                sum %= 10;
            }
            else
            {
                carryover = 0;
            }
            
            sumNode.Val = sum;
            if (lm1?.Next != null || lm2?.Next != null)
            {
                sumNode.Next = new ListNode();
                sumNode = sumNode.Next;
            }
            
            lm1 = lm1?.Next; 
            lm2 = lm2?.Next;
        }

        if (carryover == 1)
        {
            sumNode.Next = new ListNode
            {
                Val = carryover
            };
        }
        
        return head;
    }
}
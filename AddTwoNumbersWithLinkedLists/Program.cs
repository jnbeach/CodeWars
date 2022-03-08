// See https://leetcode.com/problems/add-two-numbers/ for more information
Console.WriteLine("Hello, World!");

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int carryover = 0;
        var answer = new ListNode(l1.val + l2.val, null);
        if (answer.val >= 10)
        {
            answer.val -= 10;
            carryover = 1;
        }
        else
        {
            carryover = 0;
        }
        l1 = l1.next;
        l2 = l2.next;

        while (l1 != null && l2 != null)
        {
            var newNode = new ListNode(l1.val + l2.val + carryover);
            if (newNode.val >= 10)
            {
                newNode.val -= 10;
                carryover = 1;
            }
            else
            {
                carryover = 0;
            }

            var LastNode = GetLastNode(answer);
            LastNode.next = newNode;

            l1 = l1.next;
            l2 = l2.next;
        }
        while (l1 != null)
        {
            var newNode = new ListNode(l1.val + carryover);
            if (newNode.val >= 10)
            {
                newNode.val -= 10;
                carryover = 1;
            }
            else
            {
                carryover = 0;
            }

            var LastNode = GetLastNode(answer);
            LastNode.next = newNode;
            l1 = l1.next;
        }
        while (l2 != null)
        {
            var newNode = new ListNode(l2.val + carryover);
            if (newNode.val >= 10)
            {
                newNode.val -= 10;
                carryover = 1;
            }
            else
            {
                carryover = 0;
            }

            var LastNode = GetLastNode(answer);
            LastNode.next = newNode;
            l2 = l2.next;
        }
        if (carryover == 1)
        {
            var newNode = new ListNode(carryover);
            var LastNode = GetLastNode(answer);
            LastNode.next = newNode;
        }
        return answer;
    }

    public ListNode GetLastNode(ListNode FirstNode)
    {
        var TempNode = FirstNode;
        while (TempNode.next != null)
        {
            TempNode = TempNode.next;
        }
        return TempNode;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
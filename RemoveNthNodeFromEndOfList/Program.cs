using System;

namespace RemoveNthNodeFromEndOfList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode ln = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    //next = new ListNode(3)
                    //{
                    //    next = new ListNode(4)
                    //    {
                    //        next = new ListNode(5)
                    //    }
                    //}
                }
            };
            Solution s = new Solution();
            var v = s.RemoveNthFromEnd(ln, 2);
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null && n == 1)
            {
                return null;
            }
            ListNode ln = head;//倒数第N+1个
            ListNode current = head;
            int i = 0;
            int l = 0;
            bool b = true;
            while (current.next != null)
            {
                l++;
                i++;
                current = current.next;
                if (i > n)
                {
                    ln = ln.next;
                    i--;
                    b = false;
                }
            }
            if (b && l != n)
            {
                head = head.next;
            }
            else
            {
                ln.next = ln.next.next;
            }
            return head;
        }
    }
    public class ListNode
    {
       public int val;
       public ListNode next;
       public ListNode(int x) { val = x; }
   }
}

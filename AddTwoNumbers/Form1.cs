using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddTwoNumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListNode listNode1 = new ListNode(3)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(5)
                }
            };
            ListNode listNode2 = new ListNode(3)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(5)
                }
            };
            Solution s = new Solution();
            var v = s.AddTwoNumbers(listNode1, listNode2);
        }
    }
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode root = new ListNode(0);
            ListNode v = root;
            ListNode l = l1;
            ListNode r = l2;
            int i = 0;//进位
            while (true)
            {
                if (l != null && r != null)
                {
                    int r1 = l.val + r.val + i;
                    v.next = new ListNode(r1 % 10);
                    i = r1 / 10;

                    if (l.next != null && r.next != null)
                    {

                        v = v.next;
                        l = l.next;
                        r = r.next;
                        continue;
                    }
                    if (l.next != null)
                    {
                        v = v.next;
                        l = l.next;
                        r = null;
                        continue;
                    }
                    if (r.next != null)
                    {
                        v = v.next;
                        l = null;
                        r = r.next;
                        continue;
                    }
                    if (l.next == null && r.next == null)
                    {
                        break;
                    }
                }
                if (l != null)
                {
                    int r1 = l.val + i;
                    v.next = new ListNode(r1 % 10);
                    i = r1 / 10;

                    if (l.next != null)
                    {
                        v = v.next;
                        l = l.next;
                        continue;
                    }
                    if (l.next == null)
                    {
                        break;
                    }
                }
                if (r != null)
                {
                    int r1 = r.val + i;
                    v.next = new ListNode(r1 % 10);
                    i = r1 / 10;

                    if (r.next != null)
                    {
                        v = v.next;
                        r = r.next;
                        continue;
                    }
                    if (r.next == null)
                    {
                        break;
                    }
                }
            }
            if (i!=0)
            {
                v.next.next = new ListNode(i);
            }
            return root.next;
        }
    }
    public class ListNode
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedListRandomNode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListNode node = new ListNode()
            {
                Value = 1,
                Next = new ListNode()
                {
                    Value = 2,
                    Next = new ListNode()
                    {
                        Value = 3,
                        Next = new ListNode()
                        {
                            Value = 4,
                            Next = new ListNode()
                            {
                                Value = 5,
                                Next = new ListNode()
                                {
                                    Value = 6,
                                    Next = new ListNode()
                                    {
                                        Value = 7,
                                    }
                                }
                            }
                        }
                    }
                }
            };
            Solution solution = new Solution(node);
            List<int> vs = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                var v = solution.GetRandom();
                vs.Add(v);
            }
            int i1 = vs.FindAll(x => x == 1).Count;
            int i2 = vs.FindAll(x => x == 2).Count;
            int i3 = vs.FindAll(x => x == 3).Count;
            int i4 = vs.FindAll(x => x == 4).Count;
            int i5 = vs.FindAll(x => x == 5).Count;
        }
    }

    public class Solution
    {
        public ListNode Head { get; set; }

        /** @param head The linked list's head.
            Note that the head is guaranteed to be not null, so it contains at least one node. */
        public Solution(ListNode head)
        {
            Head = head;
        }

        /** Returns a random node's value. */
        public int GetRandom()
        {
            ListNode node = Head;
            ListNode valueNode = Head;

            int i = 1;
            while (node.Next != null)
            {
                i++;
                int j = new Random(Guid.NewGuid().GetHashCode()).Next(i);
                if (j < 1)
                {
                    valueNode = node.Next;
                }
                node = node.Next;
            }
            return valueNode.Value;
        }
    }
    public class ListNode
    {
        public ListNode Next { get; set; }
        public int Value { get; set; }
    }

}

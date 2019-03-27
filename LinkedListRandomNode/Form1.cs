using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            ListNode headNode = new ListNode()
            {
                Value = 0,
            };
            ListNode node = headNode;
            for (int i = 1; i < 10; i++)
            {
                node.Next = new ListNode()
                {
                    Value = i,
                };
                node = node.Next;
            }
            Solution solution = new Solution(headNode);
            List<int> vs = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                var v = solution.GetRandom();
                vs.Add(v);
            }
            int i1 = vs.FindAll(x => x == 1).Count;
            int i2 = vs.FindAll(x => x == 2).Count;
            int i3 = vs.FindAll(x => x == 3).Count;
            int i4 = vs.FindAll(x => x == 4).Count;
            int i5 = vs.FindAll(x => x == 5).Count;
            int i6 = vs.FindAll(x => x == 6).Count;
            int i7 = vs.FindAll(x => x == 7).Count;
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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int j = new Random(Guid.NewGuid().GetHashCode()).Next(i);
                stopwatch.Stop();
                var v = stopwatch.ElapsedTicks;

                stopwatch.Restart();
                if (j < 1)
                {
                    valueNode = node.Next;
                }
                stopwatch.Stop();
                v = stopwatch.ElapsedTicks;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImplementQueueUsingStacks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class MyQueue
    {
        private Stack<int> _stack1;
        private Stack<int> _stack2;

        /** Initialize your data structure here. */
        public MyQueue()
        {

        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {

        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return 0;
        }

        /** Get the front element. */
        public int Peek()
        {
            return 0;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return true;
        }
    }

}

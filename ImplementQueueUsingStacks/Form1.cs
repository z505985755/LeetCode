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
            MyQueue q = new MyQueue();
            q.Push(1);
            q.Push(2);
            q.Push(3);
            var v = q.Pop();
            q.Push(4);
            v = q.Pop();

        }
    }
    public class MyQueue
    {
        private Stack<int> _stack1;
        private Stack<int> _stack2;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            _stack1.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            while (_stack1.Count != 0)
            {
                _stack2.Push(_stack1.Pop());
            }
            int i = _stack2.Pop();
            while (_stack2.Count != 0)
            {
                _stack1.Push(_stack2.Pop());
            }
            return i;
        }

        /** Get the front element. */
        public int Peek()
        {
            while (_stack1.Count != 0)
            {
                _stack2.Push(_stack1.Pop());
            }
            int i = _stack2.Peek();
            while (_stack2.Count != 0)
            {
                _stack1.Push(_stack2.Pop());
            }
            return i;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return _stack1.Count == 0;
        }
    }

}

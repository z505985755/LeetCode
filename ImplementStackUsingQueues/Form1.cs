using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImplementStackUsingQueues
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyStack s = new MyStack();
            s.Push(1);
            s.Push(2);
            var v = s.Pop();
            s.Push(3);
            v = s.Pop();
        }
    }
    public class MyStack
    {
        private Queue<int> _queue;
        /** Initialize your data structure here. */
        public MyStack()
        {
            _queue = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            Queue<int> buffQueue = new Queue<int>();
            while (_queue.Count != 0)
            {
                buffQueue.Enqueue(_queue.Dequeue());
            }
            _queue.Enqueue(x);
            while (buffQueue.Count != 0)
            {
                _queue.Enqueue(buffQueue.Dequeue());
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return _queue.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return _queue.Peek(); ;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return _queue.Count == 0;
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RangeSumQueryMutable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] nums1 = new int[5];
            List<int> nums2 = new List<int>();
            long s1 = 0;
            for (int i = 0; i < 5; i++)
            {
                s1 += i + 1;
                nums1[i] = i + 1;
                nums2.Add(i + 1);
            }
            NumArray numArray1 = new NumArray(nums1);
            NumArray numArray2 = new NumArray(nums2);
            numArray1.Update(0, 2);
            int sum = numArray1.SumRange(1, 3);
        }
    }
    public class NumArray
    {
        private Node RootNode;

        public NumArray(int[] nums)
        {
            RootNode = new Node();
            RootNode = CreateNode(nums.ToList(), 0, nums.Length - 1);
        }
        public NumArray(List<int> nums)
        {
            RootNode = new Node();
            RootNode = CreateNode(nums, 0, nums.Count - 1);
        }
        private Node CreateNode(List<int> nums, int leftKey, int rightKey)
        {
            Node node = new Node();
            node.LeftKey = leftKey;
            node.RightKey = rightKey;

            if (nums.Count != 1)
            {
                int sp = (int)Math.Ceiling(nums.Count / 2d) - 1;
                List<int> nums1 = nums.FindAll(x => nums.IndexOf(x) <= sp);
                List<int> nums2 = nums.FindAll(x => nums.IndexOf(x) > sp);
                node.LeftNode = CreateNode(nums1, leftKey, leftKey + sp);
                node.RightNode = CreateNode(nums2, leftKey + sp + 1, rightKey);
                node.Value = node.LeftNode.Value + node.RightNode.Value;
            }
            else
            {
                node.Value = nums[0];
            }
            return node;
        }
        public void Update(int i, int val)
        {
            UpdateNode(i, val, RootNode);
        }
        private void UpdateNode(int i, int val, Node node)
        {
            //叶子节点
            if (node.LeftKey == i && i == node.RightKey)
            {
                node.Value = val;
                return;
            }
            if (i >= node.LeftNode.LeftKey && i <= node.LeftNode.RightKey)
            {
                UpdateNode(i, val, node.LeftNode);
                node.Value = node.LeftNode.Value + node.RightNode.Value;
                return;
            }
            if (i >= node.RightNode.LeftKey && i <= node.RightNode.RightKey)
            {
                UpdateNode(i, val, node.RightNode);
                node.Value = node.LeftNode.Value + node.RightNode.Value;
                return;
            }
        }
        public int SumRange(int i, int j)
        {
            return SumRangeNode(i, j, RootNode);
        }
        private int SumRangeNode(int i, int j, Node node)
        {
            if (i == node.LeftKey && j == node.RightKey)
            {
                return node.Value;
            }
            if (i >= node.LeftNode.LeftKey && j <= node.LeftNode.RightKey)
            {
                return SumRangeNode(i, j, node.LeftNode);
            }
            if (i >= node.RightNode.LeftKey && j <= node.RightNode.RightKey)
            {
                return SumRangeNode(i, j, node.RightNode);
            }
            //拆分
            if (i <= node.LeftNode.RightKey && j >= node.RightNode.LeftKey)
            {
                return SumRangeNode(i, node.LeftNode.RightKey, node.LeftNode) + SumRangeNode(node.RightNode.LeftKey, j, node.RightNode);
            }
            return 0;
        }
    }
    public class Node
    {
        //叶子节点的LeftKey和RightKey一定相同
        public int LeftKey { get; set; }
        public int RightKey { get; set; }
        public int Value { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Trie trie = new Trie();
        private void Form1_Load(object sender, EventArgs e)
        {
            //var v1 = trie.Insert("qwe");
            //var v2 = trie.Search("qwe");
            //var v3 = trie.StartsWith("qw");
            //var v4 = trie.Search("we");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var v = trie.Insert(textBox1.Text);
            MessageBox.Show(v.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var v = trie.Search(textBox1.Text);
            MessageBox.Show(v.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var v = trie.StartsWith(textBox1.Text);
            MessageBox.Show(v.ToString());
        }
    }
    public class Trie {
        public Node RootNode { get; set; }
        public Trie()
        {
            RootNode = new Node();
        }
        public bool Insert(string str)
        {
            if (Search(str))
            {
                return false;
            }
            InsertNode(RootNode, str);
            return true;
        }
        public bool Search(string str)
        {
            return SearchNode(RootNode, str);
        }
        public bool StartsWith(string str)
        {
            return StartsWithNode(RootNode, str);
        }
        private bool HasKey(Node node, string str)
        {
            foreach (var item in node.LinkNode)
            {
                if (item.Key == str)
                {
                    return true;
                }
            }
            return false;
        }
        private bool InsertNode(Node node, string str)
        {
            string s1 = str.Substring(0, 1);
            if (HasKey(node, s1))
            {
                if (str.Length == 1)
                {
                    node[s1].IsValue = true;
                }
                else
                {
                    string s2 = str.Substring(1);
                    InsertNode(node[s1], s2);
                }
            }
            else
            {
                Node n = new Node()
                {
                    Key = s1,
                };
                node.LinkNode.Add(n);
                if (str.Length == 1)
                {
                    n.IsValue = true;
                }
                else
                {
                    string s2 = str.Substring(1);
                    InsertNode(n, s2);
                }
            }
            return true;
        }
        private bool SearchNode(Node node, string str)
        {
            string s1 = str.Substring(0, 1);
            if (HasKey(node, s1))
            {
                if (str.Length == 1)
                {
                    return node[s1].IsValue;
                }
                else
                {
                    string s2 = str.Substring(1);
                    return SearchNode(node[s1], s2);
                }
            }
            else
            {
                return false;
            }
        }
        private bool StartsWithNode(Node node, string str)
        {
            string s1 = str.Substring(0, 1);
            if (HasKey(node, s1))
            {
                if (str.Length == 1)
                {
                    return true;
                }
                else
                {
                    string s2 = str.Substring(1);
                    return StartsWithNode(node[s1], s2);
                }
            }
            else
            {
                return false;
            }
        }
    }
    public class Node
    {
        public Node()
        {
            LinkNode = new List<Node>();
        }
        public string Key { get; set; }
        public bool IsValue { get; set; }
        public List<Node> LinkNode { get; set; }
        public Node this[string key]
        {
            get
            {
                foreach (var item in LinkNode)
                {
                    if (item.Key == key)
                    {
                        return item;
                    }
                }
                return null;
            }
        }
    }
}

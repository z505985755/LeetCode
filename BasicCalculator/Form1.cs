using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "(3+2)-(1-(6+8))";
            Solution s = new Solution();
            int i = s.Calculate(str);
        }
    }
    public class Solution
    {
        public int Calculate(string s)
        {
            List<string> vs = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                vs.Add(s[i].ToString());
            }
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                if (s[i] == ')')
                {
                    int indexL = stack.Pop();
                    int indexR = i;
                    //去左右括号
                    vs[indexL] = "";
                    vs[indexR] = "";
                    //如果括号前是减号则把括号中的所有减号变成加号,加号变成减号
                    if (indexL != 0 && s[indexL - 1] == '-')
                    {
                        for (int j = indexL; j < indexR; j++)
                        {
                            if (vs[j] == "-")
                            {
                                vs[j] = "+";
                                continue;
                            }
                            if (vs[j] == "+")
                            {
                                vs[j] = "-";
                                continue;
                            }
                        }
                    }
                }
            }
            vs.RemoveAll(x => x == "");
            int res = Convert.ToInt32(vs[0]);
            for (int i = 1; i < vs.Count; i++)
            {
                if (vs[i] == "+")
                {
                    res += Convert.ToInt32(vs[i + 1]);
                }
                if (vs[i] == "-")
                {
                    res -= Convert.ToInt32(vs[i + 1]);
                }
                i++;
            }
            return res;
        }
    }
}

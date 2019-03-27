using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerWithMostWater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Solution s = new Solution();
            int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int res = s.MaxArea(height);
        }
    }
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int count = (j - i) * Math.Min(height[i], height[j]);
            while (i < j)
            {
                int count1 = (j - i) * Math.Min(height[i], height[j]);
                if (count1 > count)
                {
                    count = count1;
                }
                if (height[i] > height[j])
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sum3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Solution solution = new Solution();
            int[] vs = new int[] { -1, 0, 1, 2, -1, -4 };
            var v = solution.ThreeSum(vs, 0);
        }
    }
    public class Solution
    {
        //完全可以不用双指针,用动态规划更好吧
        public List<List<int>> ThreeSum(int[] nums, int sum)
        {
            List<List<int>> list = new List<List<int>>();
            var v = nums.ToList();
            v.Sort();
            nums = v.ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                int x = 0;
                int y = nums.Length - 1;
                while (x < y)
                {
                    if (x == i)
                    {
                        x++;
                        continue;
                    }
                    if (y == i)
                    {
                        y--;
                        continue;
                    }
                    if (x > 0 && nums[x] == nums[x - 1])
                    {
                        x++;
                        continue;
                    }
                    if (y < nums.Length - 1 && nums[y] == nums[y + 1])
                    {
                        y--;
                        continue;
                    }
                    int s = nums[i] + nums[x] + nums[y];
                    if (s == sum)
                    {
                        List<int> l = new List<int>();
                        l.Add(nums[i]);
                        l.Add(nums[x]);
                        l.Add(nums[y]);
                        list.Add(l);
                        y--;
                        x++;
                        continue;
                    }
                    if (s>0)
                    {
                        y--;
                    }
                    else
                    {
                        x++;
                    }
                }
            }
            
            return list;
        }
    }
}

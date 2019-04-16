using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongestSubstringWithoutRepeatingCharacters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "pwwkew";
            var v = Solution.LengthOfLongestSubstring(str);
        }
    }
}
public class Solution
{
    public static int LengthOfLongestSubstring(string s)
    {
        int n = s.Length, ans = 0;
        int[] index = new int[128]; // current index of character
        // try to extend the range [i, j]
        for (int j = 0, i = 0; j < n; j++)
        {
            i = Math.Max(index[s[j]], i);
            ans = Math.Max(ans, j - i + 1);
            index[s[j]] = j + 1;
        }
        return ans;
    }
}
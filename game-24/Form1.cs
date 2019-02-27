using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var v = textBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> nums = new List<double>();
            double result = Convert.ToInt32(textBox2.Text);
            foreach (var item in v)
            {
                nums.Add(Convert.ToInt32(item));
            }
            string str = Calculation(nums, result);
            if (string.IsNullOrEmpty(str))
            {
                str = "无法得出结果!";
            }
            textBox3.Text = str;
        }

        private string Calculation(List<double> nums, double result)
        {
            if (nums.Count == 1)
            {
                if (nums[0] == result)
                {
                    return result + "";
                }
                else
                {
                    return "";
                }
            }
            if (nums.Count == 2)
            {
                if (nums[0] + nums[1] == result)
                {
                    return "(" + nums[0] + "+" + nums[1] + ")";
                }
                if (nums[0] - nums[1] == result)
                {
                    return "(" + nums[0] + "-" + nums[1] + ")";
                }
                if (nums[1] - nums[0] == result)
                {
                    return "(" + nums[1] + "-" + nums[0] + ")";
                }
                if (nums[0] * nums[1] == result)
                {
                    return nums[0] + "*" + nums[1];
                }
                if (nums[0] / nums[1] == result)
                {
                    return nums[0] + "/" + nums[1];
                }
                if (nums[1] / nums[0] == result)
                {
                    return nums[1] + "/" + nums[0];
                }
                return "";
            }
            //1,3分
            for (int j = 0; j < nums.Count; j++)
            {
                double d = nums[j];
                List<double> nums1 = new List<double>(nums);
                nums1.RemoveAt(j);
                //  +

                string str = Calculation(nums1, result - d);
                if (str != "")
                {
                    return "(" + d + "+" + str + ")";
                }
                //  -
                str = Calculation(nums1, d - result);
                if (str != "")
                {
                    return "(" + d + "-" + str + ")";
                }
                str = Calculation(nums1, result - d);
                if (str != "")
                {
                    return "(" + "(" + str + ")" + "-" + d + ")";
                }
                //  *
                str = Calculation(nums1, result / d);
                if (str != "")
                {
                    return d + "*" + str;
                }
                //  
                str = Calculation(nums1, d / result);
                if (str != "")
                {
                    return d + "/" + str;
                }
                str = Calculation(nums1, result / d);
                if (str != "")
                {
                    return "(" + str + ")" + "/" + d;
                }
            }
            //2,2分
            for (int j = 0; j < nums.Count; j++)
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (j != i)
                    {
                        double d1 = nums[j];
                        double d2 = nums[i];
                        List<double> nums1 = new List<double>(nums);
                        if (i > j)
                        {
                            nums1.RemoveAt(i);
                            nums1.RemoveAt(j);
                        }
                        else
                        {
                            nums1.RemoveAt(j);
                            nums1.RemoveAt(i);
                        }
                        double newresult = d1 + d2;
                        string str1 = "(" + d1 + "+" + d2 + ")";
                        string str = Calculation(nums1, result - newresult);
                        //  +
                        if (str != "")
                        {
                            return "(" + str1 + str + ")";
                        }
                        //  -
                        str = Calculation(nums1, newresult - result);
                        if (str != "")
                        {
                            return "(" + str1 + "-" + str + ")";
                        }
                        str = Calculation(nums1, result - newresult);
                        if (str != "")
                        {
                            return "(" + str + "-" + str1 + ")";
                        }
                        //  *
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str1 + "*" + str;
                        }
                        //  
                        str = Calculation(nums1, newresult / result);
                        if (str != "")
                        {
                            return str1 + "/" + str;
                        }
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str + "/" + str1;
                        }

                        newresult = d1 - d2;
                        str1 = "(" + d1 + "-" + d2 + ")";
                        str = Calculation(nums1, result - newresult);
                        //  +
                        if (str != "")
                        {
                            return "(" + str1 + str + ")";
                        }
                        //  -
                        str = Calculation(nums1, newresult - result);
                        if (str != "")
                        {
                            return "(" + str1 + "-" + str + ")";
                        }
                        str = Calculation(nums1, result - newresult);
                        if (str != "")
                        {
                            return "(" + str + "-" + str1 + ")";
                        }
                        //  *
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str1 + "*" + str;
                        }
                        //  
                        if (newresult != 0)
                        {


                            str = Calculation(nums1, newresult / result);
                            if (str != "")
                            {
                                return str1 + "/" + str;
                            }
                            str = Calculation(nums1, result / newresult);
                            if (str != "")
                            {
                                return str + "/" + str1;
                            }
                        }

                        newresult = d2 - d1;
                        str1 = "(" + d2 + "-" + d1 + ")";
                        str = Calculation(nums1, result - newresult);
                        //  +
                        if (str != "")
                        {
                            return "(" + str1 + str + ")";
                        }
                        //  -
                        str = Calculation(nums1, newresult - result);
                        if (str != "")
                        {
                            return "(" + str1 + "-" + str + ")";
                        }
                        str = Calculation(nums1, result - newresult);
                        if (str != "")
                        {
                            return "(" + str + "-" + str1 + ")";
                        }
                        //  *
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str1 + "*" + str;
                        }
                        //  
                        if (newresult != 0)
                        {


                            str = Calculation(nums1, newresult / result);
                            if (str != "")
                            {
                                return str1 + "/" + str;
                            }
                            str = Calculation(nums1, result / newresult);
                            if (str != "")
                            {
                                return str + "/" + str1;
                            }
                        }

                        newresult = d2 * d1;
                        str1 = "(" + d2 + "*" + d1 + ")";
                        str = Calculation(nums1, result - newresult);
                        //  +
                        if (str != "")
                        {
                            return "(" + str1 + str + ")";
                        }
                        //  -
                        str = Calculation(nums1, newresult - result);
                        if (str != "")
                        {
                            return "(" + str1 + "-" + str + ")";
                        }
                        str = Calculation(nums1, result - newresult);
                        if (str != "")
                        {
                            return "(" + str + "-" + str1 + ")";
                        }
                        //  *
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str1 + "*" + str;
                        }
                        //  
                        str = Calculation(nums1, newresult / result);
                        if (str != "")
                        {
                            return str1 + "/" + str;
                        }
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str + "/" + str1;
                        }

                        newresult = d2 / d1;
                        str1 = "(" + d2 + "/" + d1 + ")";
                        str = Calculation(nums1, result - newresult);
                        //  +
                        if (str != "")
                        {
                            return "(" + str1 + str + ")";
                        }
                        //  -
                        str = Calculation(nums1, newresult - result);
                        if (str != "")
                        {
                            return "(" + str1 + "-" + str + ")";
                        }
                        str = Calculation(nums1, result - newresult);
                        if (str != "")
                        {
                            return "(" + str + "-" + str1 + ")";
                        }
                        //  *
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str1 + "*" + str;
                        }
                        //  
                        str = Calculation(nums1, newresult / result);
                        if (str != "")
                        {
                            return str1 + "/" + str;
                        }
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str + "/" + str1;
                        }

                        newresult = d1 / d2;
                        str1 = "(" + d1 + "/" + d2 + ")";
                        str = Calculation(nums1, result - newresult);
                        //  +
                        if (str != "")
                        {
                            return "(" + str1 + str + ")";
                        }
                        //  -
                        str = Calculation(nums1, newresult - result);
                        if (str != "")
                        {
                            return "(" + str1 + "-" + str + ")";
                        }
                        str = Calculation(nums1, result - newresult);
                        if (str != "")
                        {
                            return "(" + str + "-" + str1 + ")";
                        }
                        //  *
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str1 + "*" + str;
                        }
                        //  
                        str = Calculation(nums1, newresult / result);
                        if (str != "")
                        {
                            return str1 + "/" + str;
                        }
                        str = Calculation(nums1, result / newresult);
                        if (str != "")
                        {
                            return str + "/" + str1;
                        }
                    }
                }
            }
            return "";
        }
        private List<double> getNumsAndRemove(List<double> nums, int n)
        {
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private Button button2;
        private Button button1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SudokuClass sc = new SudokuClass();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var tb = this.Controls.Find("textBox" + i + "_" + j, true)[0] as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        sc[i, j] = 0;
                    }
                    else
                    {
                        sc[i, j] = Convert.ToInt32(tb.Text);
                        sc.isFixed[i, j] = true;
                    }
                }
            }
            var tag = sc.SolveSudoku();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var tb = this.Controls.Find("textBox" + i + "_" + j, true)[0] as TextBox;
                    tb.Text = sc[i, j].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }
            }
        }
        private void CreatTextBox()
        {

        }
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var textBox = new System.Windows.Forms.TextBox();
                    textBox.Location = new System.Drawing.Point(10 + j * 21 + 5 + (j / 3) * 2, 10 + i * 21 + 5 + (i / 3) * 2);
                    textBox.Name = "textBox" + i + "_" + j;
                    textBox.Size = new System.Drawing.Size(21, 21);
                    //textBox.Text = i + "" + j;
                    textBox.TabIndex = i * 10 + j;
                    this.Controls.Add(textBox);
                }
            }
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 99;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 100;
            this.button2.Text = "计算";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(222, 260);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
    public class SudokuClass
    {
        public bool[,] isFixed = new bool[10, 10];
        private Block[,] matrix = new Block[3,3];
        public SudokuClass()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = new Block();
                }
            }
        }
        public int this[int x, int y]
        {
            set { matrix[x / 3, y / 3][x % 3, y % 3] = value; }
            get { return matrix[x / 3, y / 3][x % 3, y % 3]; }
        }
        private bool Check(int x, int y, int num)
        {
            //检查行和列
            for (int i = 0; i < 9; i++)
            {
                if (this[x, i] == num || this[i, y] == num)
                {
                    return false;
                }
            }
            //检查块

            if (!matrix[x/3, y/3].Check(num))
            {
                return false;
            }

            return true;
        }
        public bool SolveSudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //对没有的数字进行操作
                    if (this[i, j] == 0)
                    {
                        if (filling(i, j))
                        {
                            return true;
                        }
                        else return false;
                    }
                }
            }
            return false;
        }
        public bool filling(int x, int y)
        {
            //计算完毕,返回真
            if (x > 8)
            {
                return true;
            }
            for (int i = 1; i < 10; i++)
            {
                if(Check(x, y, i))
                {
                    int x1 = x, y1 = y;
                    while (true)
                    {

                        if (y1 == 8)
                        {
                            x1 = x1 + 1;
                            y1 = 0;
                        }
                        else
                        {
                            y1 = y1 + 1;
                        }
                        if (!isFixed[x1, y1])
                        {
                            break;
                        }
                    }
                    //对下一个进行填充
                    this[x, y] = i;
                    var v = filling(x1,y1);
                    if (!v)
                    {
                        this[x, y] = 0;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            //1-9都试过,返回假,开始回溯
            return false;
        }
    }
    public class Block
    {
        private int[,] matrix = new int[3, 3];
        public int this[int x, int y]
        {
            set { matrix[x, y] = value; }
            get { return matrix[x, y]; }
        }
        public bool Check(int num)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

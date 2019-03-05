using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectangleArea2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //用扫描线的方式实现
        }
        public long RectangleArea(int[][] rectangles)
        {

            //如何构造这玩意
            List<LineList> List = new List<LineList>();

            for (int i = 0; i < rectangles.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                }
            }


            long Area = 0;
            for (int i = 0; i < List.Count - 1; i++)
            {
                int wight = 0;
                foreach (var item in List[i].Lines)
                {
                    wight += item.Right - item.Left;
                }
                Area += wight * (List[i + 1].Y - List[i].Y);
            }
            return Area;
        }
    }
    public class LineList
    {
        /// <summary>
        /// Y坐标,当前Y坐标下的线段集合
        /// </summary>
        public int Y { get; set; }
        public List<Line> Lines { get; set; }
    }
    public class Line
    {
        /// <summary>
        /// 左端点的X坐标
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// 右端点的X坐标
        /// </summary>
        public int Right { get; set; }
    }
}

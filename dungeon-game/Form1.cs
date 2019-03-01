using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dungeon_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[,] map = new int[3, 3] { { -2, -3, 3 }, { -5, -10, 1 }, { 10, 30, -5 } };
            Dungeon d = new Dungeon(map);
            int i = d.Calculate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewCellStyle.BackColor = Color.Blue;
            dataGridView1.Rows[0].Cells[0].Style = dataGridViewCellStyle;
        }
    }
    public class Dungeon
    {
        private int[,] map;
        public Dungeon(int[,] map)
        {
            this.map = map;
        }
        public int Calculate()
        {
            return Optimal(0, 0);
        }
        //还可以用动态规划做进一步优化
        private int Optimal(int x, int y)
        {
            int xc = map.GetLength(0);
            int yc = map.GetLength(1);
            if (x + 1 == xc && y + 1 == yc)
            {
                return map[x, y];
            }
            if (x + 1 > xc || y + 1 > xc)
            {
                return int.MinValue;
            }
            int xd = x + 1, yd = y;//向下
            int xr = x, yr = y + 1;//向右
            int sd = Optimal(xd, yd);
            int sr = Optimal(xr, yr);
            if (sd < sr)//向下
            {
                return map[x, y] + sr;
            }
            else
            {
                return map[x, y] + sd;
            }
        }
    }
}

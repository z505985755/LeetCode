using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skyline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            List<int> list2 = new List<int>();
            list2.Add(2);
            list2.Add(3);
            list1.RemoveAll(x => list2.Contains(x));

        }
        public List<Point> GetSkyline(int[,] buildings)
        {
            return null;
        }
    }
    public class Building
    { 
        /// <summary>
        /// 左X坐标
        /// </summary>
        public int Li { get; set; }
        /// <summary>
        /// 右X坐标
        /// </summary>
        public int Ri { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Hi { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Wi {
            get {
                return Ri - Li;
            }
        }
        public Building(int li, int ri, int hi)
        {
            Li = li;
            Ri = ri;
            Hi = hi;
        }
    }
    public class Graph
    {
        public List<Point> Vertexes { get; set; }
        public static Graph Skyline(Graph graph1, Graph graph2)
        {
            return new Graph();
        }
    }
}

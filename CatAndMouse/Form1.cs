using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatAndMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class Graph
    {
        public Cat Cat { get; set; }
        public Mouse Mouse { get; set; }
        /// <summary>
        /// 对当前局势进行评估的函数
        /// </summary>
        /// <returns></returns>
        public int EvaluateCat(Cat cat, Mouse mouse)
        {
            return 0;
        }

        public int EvaluateMouse(Cat cat, Mouse mouse)
        {
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat">猫的位置</param>
        /// <param name="mouse">鼠的位置</param>
        /// <param name="depth">深度</param>
        public void Next(Cat cat, Mouse mouse, int depth)
        {
            Cat catTemp = new Cat();
            Mouse mouseTemp = new Mouse();
            catTemp.Position = Cat.Position.LinkNode[0];
            int t = EvaluateCat(catTemp, Mouse);
            Node node = new Node();
            foreach (var item in Cat.Position.LinkNode)
            {
                catTemp.Position = item;
                int t1 = EvaluateCat(catTemp, Mouse);
                if (t1 > t)
                {
                    t = t1;
                    node = item;
                }
            }

        }
    }
    public class Node
    {
        public string NodeName { get; set; }
        public List<Node> LinkNode { get; set; }
    }
    public class Cat
    {
        public string Name { get; set; }
        public Node Position { get; set; }
    }
    public class Mouse
    {
        public string Name { get; set; }
        public Node Position { get; set; }
    }
}

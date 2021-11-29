using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diploma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Edge Edge;
        Graphics G;
        public List<Vertex> vs;
        public List<Vertex> clones;
        public List<Edge> es;
        bool b = true;
        int selectCounter;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            b = true;
            if (vs.Count != 0)
                foreach (Vertex ver in vs)
                {
                    if (ver.IsAlready(e.X, e.Y))
                    {
                        b = false;
                        if (ver.isSelected)
                        {
                            ver.Deselect();
                            Invalidate();
                            if(selectCounter>0)
                            selectCounter--;
                        }
                        else
                        if (selectCounter < 2)
                        {
                            ver.Select();
                            Invalidate();
                            selectCounter++;
                        }
                    }
                }
            if(b)
            {
                Vertex v = new Vertex(e.X, e.Y, G);
                vs.Add(v);
            }
            //label1.Text = selectCounter.ToString();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(vs.Count !=0 )
                foreach (Vertex v in vs)
                {
                    v.Draw();
                }
            if (es.Count != 0)
                foreach (Edge edge in es)
                {
                    edge.Draw();
                    //G.DrawLine(new Pen(Color.Black), 0, 10, 800, 500);
                }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            es = new List<Edge>();
            vs = new List<Vertex>();
            clones = new List<Vertex>();
            G = this.CreateGraphics();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Vertex v in vs)
            {
                if (v.isSelected)
                {
                    clones.Add(v);
                }
            }
            if (clones.Count > 1)
            {
                Edge = new Edge(clones[0], clones[1], G);
                es.Add(Edge);
                label1.Text += Edge.x1 + " " + Edge.x2;
                clones.Clear();
            }
            Invalidate();
        }
    }
}

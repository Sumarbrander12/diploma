using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diploma
{
    public class Edge
    {
        public int x1, x2, y1, y2;
        Graphics G;
        Pen pen;
        public Edge(Vertex v1, Vertex v2, Graphics g)
        {
            x1 = v1.X;
            y1 = v1.Y;
            x2 = v2.X;
            y2 = v2.Y;
            pen = new Pen(Color.Black);
            G = g;
        }
        public void Draw()
        {
            G.DrawLine(pen,x1,y1,x2,y2);
        }
    }
}

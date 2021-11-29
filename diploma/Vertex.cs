using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diploma
{
    public class Vertex
    {
        static int Num;
        public int X, Y, NumCarr;
        static public int diam =17;
        int extraX;
        Graphics G;
        Pen pen;
        Brush brush,brush2;
        Rectangle rec;
        Font font;
        public bool isSelected;

        public Vertex(int x, int y, Graphics g)
        {
            diam = 17;
            X = x - diam / 2;
            Y = y - diam / 2;
            G = g;
            Num++;
            NumCarr = Num;
            rec = new Rectangle(X, Y, diam, diam);
            pen = new Pen(Color.Black);
            font = new Font("Times New Roman", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            brush = Brushes.Black;
            brush2 = Brushes.White;
            isSelected = false;
            Draw();

        }
        public Vertex Clone()
        {
            Vertex clone = new Vertex(X,Y,G);
            return clone;
        }

        public void Draw()
        {
            extraX = X - 2;
            G.FillEllipse(brush, rec);
            if(NumCarr < 10)
                G.DrawString(NumCarr.ToString(), font, brush2, X+2,Y);
            else
                G.DrawString(NumCarr.ToString(), font, brush2, extraX, Y);

        }
        public void Select()
        {
            isSelected = true;
            pen = new Pen(Color.Red);
            brush = Brushes.Red;
        }
        public void Deselect()
        {
            isSelected = false;
            pen = new Pen(Color.Black);
            brush = Brushes.Black;
        }


        public bool IsAlready(int x, int y)
        {
            if (x > X && x < X + diam && y > Y && y < Y + diam)
                return true;
            else
                return false;
            
        }
    }
}

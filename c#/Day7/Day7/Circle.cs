using ClassLibraryForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Circle:Shape
    {
        public int radius;
        public Point Center;
        public Circle(int x,int y,int rad,Color c)
        {
            Center=new Point(x,y);
            radius=rad;
            color = c;
        }
        public override void Draw()
        {
            DrawingClass.DrawCircle(color,Center.X,Center.Y,radius,true);
        }
    }
}

using ClassLibraryForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Rect:Shape
    {
        Point Start;
        int width;
        int height;
        public Rect(int x1,int y1,int w,int h,Color c)
        {
            Start = new Point(x1,y1);
            width = w;
            height = h;
            color = c;
        }
        public override void Draw()
        {
           DrawingClass.DrawRectangle(color,Start.X,Start.Y,width,height);
        }
    }
}

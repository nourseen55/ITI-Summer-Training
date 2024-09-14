using ClassLibraryForms;
using System.Drawing;
namespace Day7
{

    internal class Program
    {
        static void Main(string[] args)
        {
            DrawingClass.StartDraw(800,600,"Gggg");

            Line line = new Line(300,300,500,500,System.Drawing.Color.White);
            Circle c = new Circle(250, 250, 80, System.Drawing.Color.White);
            Rect rect =new Rect(100,100,90,130,Color.White);
            Shape[] shapes = {line,c, rect};
            Picture p =new Picture(shapes);
            p.DrawPicture();
            DrawingClass.EndDraw();

        }
    }
}

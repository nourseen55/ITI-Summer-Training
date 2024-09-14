
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Picture
    {
        private Shape[] shapes;
        public Picture(Shape[] shape)
        {
            shapes = shape;
        }
        public void DrawPicture()
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }

        }
    }
}

namespace day6iti
{
    public class GeoShape
    {
        protected double dim1 { get; set; }
        protected double dim2 { get; set; }
        public GeoShape()
        {
            dim1 = dim2 = 1;
        }
        public GeoShape(double n)
        {
            dim2 = dim1 = n;
        }
        public GeoShape(double n1, double n2)
        {
            dim1 = n1;
            dim2 = n2;

        }
        public virtual double calcarea()
        {
            return 0;
        }
    }
        public class circle : GeoShape
    {
        public circle(int n) : base(n)
        {

        }
        public double raduis { get { return dim1; } set { dim1 = value; } }
        public override double calcarea()
        {
            return Math.PI * Math.Pow(raduis, 2);
        }

    }
        public class rectangle : GeoShape
        {
            public rectangle(double  n, double n1) : base(n, n1)
            {

            }
            public double Width {get { return dim1; } set { dim1 = value; } }
            public double Height { get { return dim2; } set { dim2 = value; } }
            public override double calcarea() { 
                return Width * Height;
            }
        }
        public class traingle : GeoShape
        {
            public traingle(double n1, double n2) : base(n1, n2)
            {

            }
            public double Base {get { return dim1; } set { dim1 = value; } }
            public double Height { get{ return dim2; } set { dim2 = value; } }

           
        public override double calcarea()
        {
            return 0.5* Base * Height;
        }
    }

        internal class Program
        {
        static void Main(string[] args)
        {
            circle c = new circle(5);
            traingle t=new traingle(5, 15);
            rectangle r = new rectangle(5, 10);
            GeoShape[] garr = { c, t, r };
            double sum = 0;
            foreach (var item in garr)
            {

                sum+=item.calcarea();
                
            }
            Console.WriteLine(sum);

        }
    }
}

namespace Day4iti
{
    using ClassLibrary1;
    using System.Runtime.InteropServices;
   
    internal class Program
    {
        struct Complex
        {
            public float real;
            public float imaginary;
            public Complex(float real, float imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
                
            }
        }
        static Complex addcomplex(Complex complex1, Complex complex2)
        {
            Complex newcomplex = new Complex();
            newcomplex.real = complex1.real + complex2.real;
            newcomplex.imaginary = complex1.imaginary + complex2.imaginary;
            return newcomplex;
        }
        static Complex substractcomplex(Complex complex1, Complex complex2)
        {
            Complex newcomplex = new Complex();
            newcomplex.real = complex1.real - complex2.real;
            newcomplex.imaginary = complex1.imaginary - complex2.imaginary;
            return newcomplex;
        }
        static void Main(string[] args)
        {
            Employee employee = new Employee(1, "nourseen");


            Complex c1 = new Complex(2f,145);
            Complex c2 = new Complex(4, 58.5f);
 
            Console.WriteLine($"real: {addcomplex(c1, c2).real} img: {addcomplex(c1, c2).imaginary}");
            Console.WriteLine($"real: {substractcomplex(c1, c2).real} img: {substractcomplex(c1, c2).imaginary}");




        }
    }
    
}

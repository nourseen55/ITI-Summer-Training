namespace factorial
{
    internal class Program
    {
        public static int fact(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * fact(n - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number To Get The Factorial");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(fact(num));

        }
    }
}

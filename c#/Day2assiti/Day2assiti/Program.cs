namespace Day2assiti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get Average
            //Console.WriteLine("Enter Num 1");
            //int n1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter Num 2");
            //int n2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"Average Num {(n1 + n2) / 2}");

            //Get Max
            //Console.WriteLine("Enter Num 1");
            //int n1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter Num 2");
            //int n2 = Convert.ToInt32(Console.ReadLine());
            //if (n1 > n2)
            //{
            //    Console.WriteLine($"Max Is {n1}");

            //}
            //else if (n2 > n1)
            //{
            //    Console.WriteLine($"Max Is {n2}");

            //}
            //else
            //{
            //    Console.WriteLine("Two numbers are equal");
            //}

            //simple menu
            //Console.WriteLine("Select from Menu{Min,Max,Sum}");
            //string select = Console.ReadLine();
            //Console.WriteLine("Enter Num 1");
            //int n1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter Num 2");
            //int n2 = Convert.ToInt32(Console.ReadLine());
            //switch (select)
            //{
            //    case "Max":

            //        if (n1 > n2)
            //        {
            //            Console.WriteLine($"Max Is {n1}");

            //        }
            //        else if (n2 > n1)
            //        {
            //            Console.WriteLine($"Max Is {n2}");

            //        }
            //        else
            //        {
            //            Console.WriteLine("Two numbers are equal");
            //        }
            //        break;
            //    case "Min":

            //        if (n1 < n2)
            //        {
            //            Console.WriteLine($"Min Is {n1}");

            //        }
            //        else if (n1 < n2)
            //        {
            //            Console.WriteLine($"Min Is {n2}");

            //        }
            //        else
            //        {
            //            Console.WriteLine("Two numbers are equal");
            //        }
            //        break;
            //    case "Sum":

            //        Console.WriteLine($"Sum Is {n1 + n2}");
            //        break;
            //}

            //Simple Calculator
            Console.WriteLine("Choose +, -, *, /");
            char op = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter Num 1");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Num 2");
            int num2 = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case '+':
                    Console.WriteLine($"Sum Is {num1 + num2}");
                    break;
                case '-':
                    Console.WriteLine($"Substraction Is {num1 - num2}");
                    break;
                case '*':
                    Console.WriteLine($"Multiplication Is {num1 * num2}");
                    break;
                case '/':
                    Console.WriteLine($"Division Is {num1 / num2}");
                    break;
            }

        }

    }
}

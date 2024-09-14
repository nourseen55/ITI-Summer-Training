using System;
using System.Collections.Generic;

namespace Menu
{
    class SortByNameAsc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Arguments cannot be null");
            }
            return x.Name.CompareTo(y.Name);
        }
    }

    class SortByNameDesc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return -1 * x.Name.CompareTo(y.Name);
        }
    }

    class SortBySalaryAsc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }

    class SortBySalaryDesc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return -1 * x.Salary.CompareTo(y.Salary);
        }
    }

    public class Human
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return ($"Employee Name: {Name} Employee Age: {Age} Employee Gender: {Gender}");
        }
    }

    public class Employee : Human, IComparable
    {
        public int Id;
        private static int c = 0;
        public double Salary { get; set; }

        public Employee(string gender, string name, double salary, int age)
        {
            Id = c++;
            Gender = gender;
            base.Name = name;
            Salary = salary;
            base.Age = age;
        }

        public override string ToString()
        {
            return ($"Employee ID: {Id} \nEmployee Name: {Name} \nEmployee Age: {Age}\nEmployee Gender: {Gender}\nEmployee Salary: {Salary}\n---------------");
        }

        public int CompareTo(object obj)
        {
            Employee emp = obj as Employee;
            return this.Salary.CompareTo(emp.Salary);
        }
    }

    static class Test
    {
        public static void DisplayEmployeeDetails(this List<Employee> arr)
        {
            Console.Clear();
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] != null)
                {
                    Console.WriteLine(arr[i].ToString());
                }
                else
                {
                    Console.WriteLine("No data for this employee.");
                }
            }
            Console.ReadKey();
        }
    }

    internal class EmployeeManagement
    {
        private static string ReadNonEmptyString(string prompt)
        {
            string input;
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("Input cannot be empty.");
                    }
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return input;
        }

        private static int ReadInt(string prompt)
        {
            int input;
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input <= 0)
                    {
                        throw new ArgumentException("Input must be a positive integer.");
                    }
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            return input;
        }

        private static double ReadDouble(string prompt)
        {
            double input;
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    input = Convert.ToDouble(Console.ReadLine());
                    if (input <= 0)
                    {
                        throw new ArgumentException("Input must be a positive number.");
                    }
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return input;
        }

        public static void RegisterNewEmployee(ref List<Employee> arr)
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                string name = ReadNonEmptyString("Enter Employee Name:");
                int age = ReadInt("Enter Employee Age:");
                string gender = ReadNonEmptyString("Enter Employee Gender:");
                double salary = ReadDouble("Enter Employee Salary:");

                arr.Add(new Employee(gender, name, salary, age));
                Console.WriteLine("--------------------");
            }
        }

        static void Main(string[] args)
        {
            List<Employee> arremps = new List<Employee>();
            string[] menuOptions = { "Register", "Sort", "Display", "Exit" };
            int selectedIndex = 0;
            bool isRunning = true;
            int horizontalCenter = Console.WindowWidth / 2;
            int verticalCenter = Console.WindowHeight / (menuOptions.Length + 1);

            do
            {
                Console.Clear();
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(horizontalCenter, verticalCenter * (i + 1));
                    Console.Write(menuOptions[i]);
                }

                ConsoleKeyInfo keyPressed = Console.ReadKey();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = menuOptions.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex >= menuOptions.Length)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Home:
                        selectedIndex = 0;
                        break;
                    case ConsoleKey.End:
                        selectedIndex = menuOptions.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (selectedIndex)
                        {
                            case 0:
                                RegisterNewEmployee(ref arremps);
                                break;
                            case 1:
                                Console.WriteLine("Sort by Name or Salary");
                                string sortby = ReadNonEmptyString("Sort by Name or Salary:");

                                if (sortby.Equals("Salary", StringComparison.OrdinalIgnoreCase))
                                {
                                    string order = ReadNonEmptyString("Asc or Desc?");
                                    if (order.Equals("Asc", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine("Sort By Salary Ascending");
                                        arremps.Sort(new SortBySalaryAsc());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort By Salary Descending");
                                        arremps.Sort(new SortBySalaryDesc());
                                    }
                                    arremps.DisplayEmployeeDetails();
                                }
                                else if (sortby.Equals("Name", StringComparison.OrdinalIgnoreCase))
                                {
                                    string order = ReadNonEmptyString("Asc or Desc?");
                                    if (order.Equals("Asc", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine("Sort By Name Ascending");
                                        arremps.Sort(new SortByNameAsc());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort By Name Descending");
                                        arremps.Sort(new SortByNameDesc());
                                    }
                                    arremps.DisplayEmployeeDetails();
                                }
                                break;
                            case 2:
                                arremps.DisplayEmployeeDetails();
                                break;
                            case 3:
                                isRunning = false;
                                break;
                        }
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                }
            } while (isRunning);
        }
    }
}

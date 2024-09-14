using System;
using System.Collections.Generic;

namespace Menu
{
    public enum Gender
    {
        Female,
        Male
    }
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
        public Gender Gender { get; set; }
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

        public Employee(Gender gender, string name, double salary, int age)
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

        private static Gender ReadGender(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt + " (Male, Female):");
                    string input = Console.ReadLine();
                    if (Enum.TryParse(input, out Gender gender))
                    {
                        return gender;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid gender. Please enter Male Or Female.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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
            string name = ReadNonEmptyString("Enter Employee Name:");
            int age = ReadInt("Enter Employee Age:");
            Gender gender = ReadGender("Enter Employee Gender");
            double salary = ReadDouble("Enter Employee Salary:");

            arr.Add(new Employee(gender, name, salary, age));
            Console.WriteLine("--------------------");

            string addMore = ReadNonEmptyString("Do you want to add another employee? (yes/no):");
            if (addMore.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                RegisterNewEmployee(ref arr);
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
                                string sortby = ReadNonEmptyString("Sort by Name or Salary:");

                                if (sortby=="Salary")
                                {
                                    string order = ReadNonEmptyString("Asc or Desc?");
                                    if (order=="Asc")
                                    {
                                        Console.WriteLine("Sort By Salary Ascending");
                                        //arremps.Sort(new SortBySalaryAsc());
                                        arremps.Sort((c1, c2) => c1.Salary.CompareTo(c2.Salary));
                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort By Salary Descending");
                                        //arremps.Sort(new SortBySalaryDesc());
                                        arremps.Sort((c1, c2) => -1*c1.Salary.CompareTo(c2.Salary));

                                    }
                                    arremps.DisplayEmployeeDetails();
                                }
                                else if (sortby == "Name")
                                {
                                    string order = ReadNonEmptyString("Asc or Desc?");
                                    if (order=="Asc")
                                    {
                                        Console.WriteLine("Sort By Name Ascending");
                                        //arremps.Sort(new SortByNameAsc());
                                        arremps.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));

                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort By Name Descending");
                                        //arremps.Sort(new SortByNameDesc());
                                        arremps.Sort((c1, c2) => -1*c1.Name.CompareTo(c2.Name));

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

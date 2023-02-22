using System;

namespace SealedClass
{
    class Program
    {
        interface IEmployee
        {
            //Properties
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            //Methods
            public string Fullname();
            public double Pay();
        }
        class Employee : IEmployee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Employee()
            {
                Id = 0;
                FirstName = string.Empty;
                LastName = string.Empty;
            }
            public Employee(int id, string firstName, string lastName)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
            }
            public string Fullname()
            {
                return FirstName + " " + LastName;
            }
            public virtual double Pay()
            {
                double salary;
                Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
                salary = double.Parse(Console.ReadLine());
                return salary;
            }

        }
        sealed class Executive : Employee
        {
            public string Title;
            public double Salary;

            public Executive() : base()
            {
                Title = "Administrator";
                Salary = 2000;
            }
            public Executive(int id, string firstName, string lastName, string title, double salary)
            {
                Title = title;
                Salary = salary;
            }

            public override double Pay()
            {
                return Salary;
            }
        }
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Id = 1001;
            emp.FirstName = "Bob";
            emp.LastName = "Evans";

            Executive exec = new Executive();
            exec.Id = 9999;
            exec.FirstName = "Sara";
            exec.LastName = "Lee";
            exec.Title = "Grand Poo-bah";
            exec.Salary = 5000;

            Console.WriteLine("Employee Information");
            Console.WriteLine("ID: " + emp.Id);
            Console.WriteLine("Name: " + emp.Fullname());
            emp.Pay();
            Console.WriteLine();
            Console.WriteLine("Executive Information");
            Console.WriteLine("ID: " + exec.Id);
            Console.WriteLine("Name: " + exec.Fullname());
            Console.WriteLine("Title: " + exec.Title);
            Console.WriteLine("Salary: " + exec.Salary + " per week");
        }
    }
}
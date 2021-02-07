using System;

namespace BakeryOpenning
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Bakery bakery = new Bakery("Barny", 3);

            Employee employee = new Employee("Stephen", 40, "Bulgaria");
            //Print Employee
            Console.WriteLine(employee); //Employee: Stephen, 40 (Bulgaria)

            //Add Employee
            bakery.Add(employee);

            //Remove Employee
            Console.WriteLine(bakery.Remove("Employee name"));

            Employee secondEmployee = new Employee("Mark", 34, "UK");

            //Add Employee
            bakery.Add(secondEmployee);

            Employee oldestEmployee = bakery.GetOldestEmployee(); // Employee with name Stephen
            Employee employeeStephen = bakery.GetEmployee("Stephen"); // Employee with name Stephen
            Console.WriteLine(oldestEmployee); //Employee: Stephen, 40 (Bulgaria)
            Console.WriteLine(employeeStephen); //Employee: Stephen, 40 (Bulgaria)



            Console.WriteLine(bakery.Count); //3

            Console.WriteLine(bakery.Report());
            //Employees working at Bakery Barny:
            //Employee: Stephen, 40 (Bulgaria)
            //Employee: Mark, 34 (UK)


            Employee thirdEmployee = new Employee("Prakash", 22, "India");

            //Add Employee
            bakery.Add(thirdEmployee);

            Console.WriteLine(bakery.Remove("Prakash"));

        }
    }
}

using System;
using System.Collections.Generic;

namespace EmployeeWageComputation
{
    class Program
    {
        /// <summary>
        /// full day hours, part time hours and per hour wage
        /// </summary>
        const int FULL_TIME = 8;
        const int PART_TIME = 4;
        const int WAGE_PER_HOUR = 20;
        static void Main(string[] args)
        {

            int employeeMonthlyWage;

            // data structure to store daily wage corresponding toe each day
            Dictionary<string, int> dailyWage = new Dictionary<string, int>();

            Console.WriteLine("Welcome To Employee Wage Computation  Problem");
            Console.WriteLine("-------Employee Computation--------");

            // employee instance            
            EmployeeWage employee = new EmployeeWage(FULL_TIME, PART_TIME, WAGE_PER_HOUR);

            // calculating the total monthly wage for employee instance
            employeeMonthlyWage = employee.MonthlyWage(dailyWage);

            // printing the daily wage
            foreach (var item in dailyWage)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

            Console.WriteLine($"Total Monthly Wage : {employeeMonthlyWage}");
            Console.WriteLine("Wages Calculated Reached The Condition");
        }
    }
}

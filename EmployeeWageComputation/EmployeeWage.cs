using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeWageComputation
{
    class EmployeeWage
    {
        /// <summary>
        /// constants same for every employee
        /// </summary>
        const int MONTHLY_WORKING_DAYS = 20;
        const int PRESENT = 0;
        const int NO_WAGE = 0;
        const int MONTHLY_MAX_WORKING_HOURS = 100;
        const int DAYS_IN_MONTH = 30;

        int fullDayHour;
        int partTimeHour;
        int wagePerHour;
        int empType;
        int workHours;
        int wageForADay;
        bool employeePresent;
        int workingHoursForMonth = 0;
        int days = 0;
        public EmployeeWage(int fullTime, int partTime, int wagePerHour)
        {
            this.fullDayHour = fullTime;
            this.partTimeHour = partTime;
            this.wagePerHour = wagePerHour;
        }
        public bool EmployeeAttendance()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(0, 2) == PRESENT ? true : false;
        }
        public int DailyEmployeeWage(int wage, int workingHours)
        {
            return wage * workingHours;
        }
        public int GetworkingHoursForDay(int workingHoursForMonth)
        {
            Random randomNum = new Random();
            empType = randomNum.Next(0, 2);

            // cheking employee type part time or full time
            switch (empType)
            {
                case 0:
                    workHours = fullDayHour;
                    break;
                case 1:
                    workHours = partTimeHour;
                    break;
                default:
                    break;
            }

            // situation when employee has worked for 96 hours, and comes next day for full day
            if ((MONTHLY_MAX_WORKING_HOURS - workingHoursForMonth) < fullDayHour)
            {
                workHours = partTimeHour;
            }
            return workHours;
        }
        public void CalculateWorkingHoursAndWage(int daysWorkedInMonth)
        {
            // cheking if employee is present or not
            if (employeePresent == true)
            {
                //getting working hours for day according to full time or part time employee
                workHours = GetworkingHoursForDay(workingHoursForMonth);

                // Daily wage
                wageForADay = this.DailyEmployeeWage(wagePerHour, workHours);

                // incrementing worked day by 1
                daysWorkedInMonth++;

                // adding hours worked in day to monthly worked hours
                workingHoursForMonth += workHours;
            }
            else
            {
                wageForADay = NO_WAGE;      // Daily wage
            }
        }
        public int MonthlyWage(Dictionary<string, int> dictionary)
        {
            int employeeMonthlyWage = 0;
            int daysWorkedInMonth = 0;

            // calculating wage for max of 100 hours or 20 days of work done or 30 days aka month gets over
            while (daysWorkedInMonth < MONTHLY_WORKING_DAYS && workingHoursForMonth < MONTHLY_MAX_WORKING_HOURS && days < DAYS_IN_MONTH)
            {
                employeePresent = this.EmployeeAttendance();

                CalculateWorkingHoursAndWage(daysWorkedInMonth);

                days++;
                dictionary[$"Day {days}"] = wageForADay;

                // Caclulating monthly wage
                employeeMonthlyWage += wageForADay;

            }
            return employeeMonthlyWage;
        }

    }
}

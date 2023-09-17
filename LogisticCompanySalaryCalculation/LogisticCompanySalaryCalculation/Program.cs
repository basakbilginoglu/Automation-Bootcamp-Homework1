using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompanySalaryCalculation
{
     class Program
    {
        static void Main(string[] args)
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo berlinZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime berlinTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc,berlinZone);
            Console.WriteLine("Berlin time:" + berlinTime);

            Console.Write("Enter employee's name: ");
            string employeeName= Console.ReadLine();

            Console.Write("Enter Emloyee's start time (HH:MM:mm): ");
            string startTime=Console.ReadLine();
            DateTime startTimeDateTime=DateTime.Parse(startTime);
            Console.Write("Enter Emloyee's end time (HH:MM:mm): ");
            string endTime=Console.ReadLine();
            DateTime endTimeDateTime = DateTime.Parse(endTime);
            Console.Write("if employee take break time please enter: ");
            string breakTime=Console.ReadLine();
            DateTime breakTimeDateTime = DateTime.Parse(breakTime);
            
            Employee employee = new Employee(employeeName, startTimeDateTime, endTimeDateTime, breakTimeDateTime);

            Console.WriteLine("Employee Worked :" + employee.calculateWorkingHours() + "Hours" +
                " Employee's overWoking is " + employee.calculateSalary(breakTimeDateTime));

        }
        
        class Employee
        {
            public Employee(string name, DateTime jobStartTime, DateTime jobEndTime,DateTime breakTime)
            {
                Name = name;
                JobStartTime = jobStartTime;
                JobEndTime = jobEndTime;
                BreakTime = breakTime;
               
            }

            public string Name{ get; set; }
            public DateTime JobStartTime { get; set; }
            public DateTime JobEndTime { get; set; }
            public DateTime BreakTime { get; set; }
            public int OverWorking { get; set; }
            public int calculateWorkingHours()
            {
                int workingHours = (JobStartTime.Hour - JobEndTime.Hour) - BreakTime.Hour;
                return workingHours;

            }

            public int calculateSalary(DateTime breakTime)
            {  
                //Normal çalışma 8 saat olarak alındı
                if (calculateWorkingHours() > 8)
                {
                    int salary = ((JobEndTime-JobStartTime).Minutes)*60 - breakTime.Hour-8*50;

                    return salary;
                }
                else
                {
                    Console.WriteLine("OverWorking is not made");
                    return 0;
                }
                
            }
        }

    }
}


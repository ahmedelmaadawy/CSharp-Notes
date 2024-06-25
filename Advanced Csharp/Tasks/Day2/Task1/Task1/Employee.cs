using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Employee
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public HireDate HireDate { get; set; }
        public SecurityPrivilage SecurityLevel { get; set; }

        public Employee(int id,Gender gender,int salary,HireDate hireDate,SecurityPrivilage security)
        {
            this.Id = id;
            this.Gender = gender;
            this.Salary = salary;
            this.HireDate = hireDate;
            this.SecurityLevel = security;
        }
        /// <summary>
        /// Formats the employees data
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return string.Format("ID: {0}\nGender: {1}\nSalary: {2:c}\nHireDate: {3:d},\nSecurityLevel: {4}",Id,Gender,Salary,HireDate,SecurityLevel);
        }
        /// <summary>
        /// This Method takes a reference to array of employee and sort the array
        /// </summary>
        /// <param name="employees"></param>

        public static void Sort(ref Employee[] employees) {
            Employee temp;
            for (int i = 0; i < employees?.Length; i++) {
                for (int j = 0; j < employees.Length; j++) {
                    if (employees[i].HireDate > employees[j].HireDate) {
                        temp = employees[i];
                        employees[i] = employees[j];
                        employees[j] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// This Method Takes array of Employees and prints them
        /// in a good format    
        /// </summary>
        /// <param name="employees"></param>
        public static void DisplayEmployees(Employee[] employees) {

            for (int i = 0; i < employees?.Length; i++)
            {
                Console.WriteLine($"Employee NO:  {i+1}");
                Console.WriteLine("----------------");
                Console.WriteLine(employees[i]);
                Console.WriteLine("-----------------");
            }

        }
    }
}

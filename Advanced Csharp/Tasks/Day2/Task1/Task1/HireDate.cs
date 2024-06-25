using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal struct HireDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireDate(int day ,int month,int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }
        /// <summary>
        /// Formats the data of hire date
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Day}\\{Month}\\{Year}";
        }
        /// <summary>
        /// This method compares two hiredate and returns if the first one is newer than the second
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>bool if the first hire date is newer than the second returns true otherwise false</returns>

        public static bool  operator > (HireDate a, HireDate b)
        {
            if(a.Year>b.Year)
                return true ;
            if(a.Year == b.Year && a.Month>b.Month)
                return true ;
            if (a.Year == b.Year && b.Month==a.Month && a.Day > b.Day)
                return true ;
            return false ;
        }
        /// <summary>
        /// This method compares two hiredate and returns if the first one is older than the second
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>bool if the first hire date is older than the second returns true otherwise false</returns>
        public static bool operator <(HireDate a, HireDate b)
        {
            if (a.Year < b.Year)
                return true;
            if (a.Year == b.Year && a.Month < b.Month)
                return true;
            if (a.Year == b.Year && b.Month == a.Month && a.Day < b.Day)
                return true;
            return false;
        }

       
    }
}

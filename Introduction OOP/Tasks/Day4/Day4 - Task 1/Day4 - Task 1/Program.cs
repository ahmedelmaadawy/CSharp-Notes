namespace Day4___Task_1
{
    struct HiringDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public HiringDate(int day,int month , int year)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
        public bool IsOlder (HiringDate date)
        {
            //returns true if the current date is older than the parameter date
            if (date.Year > this.Year)
                return true;
            else if (date.Year < this.Year)
                return false;
            else if (date.Month > this.Month)
                return true;
            else if (date.Month < this.Month)
                return false;
            else if (date.Day > this.Day)
                return true;
            else if (date.Day < this.Day)
                return false;
            return false;
        }
         
        public string GetString()
        {
            return $"{Day}\\{Month}\\{Year}";
        }
    }
    class Employee
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public HiringDate Hiredate { get; set; }
        public string Gender { get; set; }
        public Employee(int id,double salary,string gender ,HiringDate date)
        {
            this.Id = id;
            this.Hiredate = date;
            this.Salary = salary;
            this.Gender = gender;
        }
        
        public string GetString()
        {
            return $"Employee ID : {Id}\nEmployee Salary : {Salary}\nEmployee HireDate : {Hiredate.GetString()}\nEmployee Gender : {Gender}\n";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int id;
            double salary;
            string gender;
            HiringDate date= new HiringDate();
            Console.WriteLine("Please Enter the Number Of Employees");
            int size = int.Parse(Console.ReadLine());
            Employee[] employees = new Employee[size];
            for (int i = 0; i < size; i++) {
                Console.WriteLine($"Data For Employee Number {i+1}");
                Console.WriteLine("Please Enter Employee ID : ");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter Employee Salary : ");
                salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter Employee hiredate Day: ");
                date.Day = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter Employee hiredate month: ");
                date.Month = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter Employee hiredate year: ");
                date.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter the Gender (male/female): ");
                gender = Console.ReadLine();

                employees[i] = new Employee(id, salary, gender, date);
            }

            for (int i = 0; i < employees.Length; i++) {
                Console.WriteLine(employees[i].GetString());
            }
            Employee temp;
            for (int i = 0; i < employees.Length; i++)
            {
                for (int j = 0; j < employees.Length ; j++) {
                    if (employees[i].Hiredate.IsOlder(employees[j].Hiredate))
                    {
                        temp = employees[i];
                        employees[i] = employees[j];
                        employees[j] = temp;
                    }
                }
            }
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].GetString());
            }

        }
    }
}

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HireDate date = new HireDate(10,2,2024);
            Employee em =new Employee(1,Gender.Male,20000,new HireDate(1,2,2000),(SecurityPrivilage)4);

            Console.WriteLine(em);
            Employee[] EmpArr = new Employee[3];
            int[] priv = { 8, 1, 14 };  
            
            for (int i = 0; i < EmpArr.Length; i++) {
                Console.WriteLine($"**** Please Enter The {(SecurityPrivilage) priv[i]} Employee Data ****");
                int id = 0, salary = 0, day = 0, month = 0, year = 0;
                Gender gender = Gender.none;

                bool isValid = false;
                while (!isValid) {
                    Console.WriteLine("Please Enter A Valid Id");
                    isValid = int.TryParse(Console.ReadLine(), out id);
                }
                isValid=false;
                while (!isValid)
                {

                    Console.WriteLine("Please Enter A Gender 'M' OR 'F'");
                    string g =Console.ReadLine();
                    if (g != "Male" && g[0] !='F')
                        continue;
                    isValid = Enum.TryParse(g,out gender);
                    
                }
                isValid = false;
                while (!isValid)
                {
                    Console.WriteLine("Please Enter A Salary'");
                    isValid = int.TryParse((Console.ReadLine()), out salary);
                }
                isValid = false;
                while (!isValid)
                {
                    Console.WriteLine("Enter HireDate Day: ");
                    isValid = int.TryParse((Console.ReadLine()), out day);
                }
                isValid = false;
                while (!isValid)
                {
                    Console.WriteLine("Enter HireDate Month: ");
                    isValid = int.TryParse((Console.ReadLine()), out month);
                }

                isValid = false;
                while (!isValid)
                {
                    Console.WriteLine("Enter HireDate Year: ");
                    isValid = int.TryParse((Console.ReadLine()), out year);
                }
                EmpArr[i] = new Employee(id,gender,salary,new HireDate(day, month, year), (SecurityPrivilage)priv[i]);
            }
            Employee.DisplayEmployees(EmpArr);
            Employee.Sort(ref EmpArr);
            Employee.DisplayEmployees(EmpArr);


        }
    }
}

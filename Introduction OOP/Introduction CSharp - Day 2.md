# Casting
Type casting is when you assign a value of one data type to another type.
## Implicit Casting
Implicit casting (automatically) - converting a smaller type to a larger type size  
`char` -> `int` -> `long` -> `float` -> `double`
```c#
int myInt = 9;
double myDouble = myInt;       // Automatic casting: int to double

Console.WriteLine(myInt);      // Outputs 9
Console.WriteLine(myDouble);   // Outputs 9

```
## Explicit Casting
Explicit Casting (manually) - converting a larger type to a smaller size type  
`double` -> `float` -> `long` -> `int` -> `char`
```csharp
double myDouble = 9.78;
int myInt = (int) myDouble;    // Manual casting: double to int

Console.WriteLine(myDouble);   // Outputs 9.78
Console.WriteLine(myInt);      // Outputs 9
```

But be careful Explicit casting can end in losing data if you don't bay attention
if you don't want to prevent the behavior of the overflow from happening you can make the compiler be strict to throw exception in case of overflow by putting the `checked` block
Example:
```c#
checked{
	long x = int.MaxValue
	x+=100;
	//compiler will throw overflow here
	int y =(int) x; //overflow
}
```
___
# Converting Incompatible types
## Parse 
casting from string to any datatype

```csharp
string txt = "123";
int x = int.Parse(txt);// x = 123
x++;
Console.WriteLine(x); //x = 124
```
___
## Convert
It is also possible to convert data types explicitly by using built-in methods, such as `Convert.ToBoolean`, `Convert.ToDouble`, `Convert.ToString`, `Convert.ToInt32` (`int`) and `Convert.ToInt64` (`long`) 

```csharp
int myInt = 10;
double myDouble = 5.25;
string str = "10"
Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
Console.WriteLine(Convert.ToInt32(myDouble));  // convert double to int
Console.WriteLine(Convert.ToInt32(str));  // convert string to int

```

The Main difference between `Convert` and `parse` that convert doesn't throw an exception if null value is passed but `parse` can't handle `null` values but `convert` return 0 in case of `null` values

Reference :[Different between parse and convert](https://medium.com/@mmweerarathna123/difference-between-convert-and-parse-in-c-convert-toint32-int-parseint-045618a0d5b3#:~:text=Parse%20is%20different%20from%20convert,one%20data%20type%20to%20another.)
___
# Value Vs Reference Datatypes

In C#, data types are categorized into two main types: value types and reference types. Understanding the difference between these two is fundamental for managing memory and performance in your applications.
### Value Types

Value types directly contain their data. When you assign a value type to a new variable, a copy of the value is made. This means that each variable has its own copy of the data.

#### Characteristics of Value Types

1. **Stored in Stack**: Value types are stored in the stack, which is a region of memory that stores short-lived, small data.
2. **Independent Copies**: Assigning one value type variable to another creates an independent copy.
3. **Default Initialization**: Value types cannot be `null` (except nullable value types). They are initialized to their default values (e.g., `0` for `int`, `false` for `bool`).
4. **Examples**: Primitive data types (e.g., `int`, `float`, `bool`), structures (`struct`), and enumerations (`enum`).
```c#
int a = 10;
int b = a; // b gets a copy of a's value
b = 20; // Changing b does not affect a
Console.WriteLine(a); // Output: 10
Console.WriteLine(b); // Output: 20

```
### Reference Types

Reference types store references to their data. When you assign a reference type to a new variable, both variables point to the same memory location. This means that changes to the data via one variable will reflect in the other.

#### Characteristics of Reference Types

1. **Stored in Heap**: Reference types are stored in the heap, which is a region of memory used for dynamic allocation of large objects and data that need to persist for longer periods.
2. **Shared References**: Assigning one reference type variable to another creates a reference to the same memory location.
3. **Can Be Null**: Reference types can be `null`, indicating that they do not refer to any object.
4. **Examples**: Classes (`class`), arrays and delegates.
```c#
class Person
{
    public string Name { get; set; }
}

Person person1 = new Person { Name = "Alice" };
Person person2 = person1; // person2 references the same object as person1
person2.Name = "Bob"; // Changing person2 also changes person1
Console.WriteLine(person1.Name); // Output: Bob
Console.WriteLine(person2.Name); // Output: Bob

```

| Aspect            | Value Types                              | Reference Types              |
| ----------------- | ---------------------------------------- | ---------------------------- |
| **Storage**       | Stack                                    | Heap                         |
| **Containment**   | Directly contains data                   | Contains a reference to data |
| **Assignment**    | Copies the value                         | Copies the reference         |
| **Independence**  | Independent copies                       | Shared references            |
| **Default Value** | Cannot be `null` (except nullable)       | Can be `null`                |
| **Examples**      | `int`, `float`, `bool`, `struct`, `enum` | `class`, `array`, `delegate` |

___
# Control Statement
## If & If else & if elseif else

```c#
if(expresion1){
//some statements
}else if(exxpression2){
//some statements
}else{
//execute if all statements are wrong
}
```

```c#
string password ="1234";
if(password.Length <8){
	 Console.WriteLine("Your Password is too short use at least 8 characters ");
}else{
Console.WriteLine("Your Password is Strong");
}
```
## Switch case
```c#
switch (budget)
{
	case 1000:
	case 1100:
		Console.WriteLine("breackfast");
		break;
	case 1200:
		Console.WriteLine("breackfast+dinner");
		break;
	case 1400:
		Console.WriteLine("breackfast+dinner+lunch");
		break;
	default:
		Console.WriteLine("invalid budget");
		break;
}
```
___
# Looping
## While
```c#
int sum = 0;
while (sum < 100)
{
	Console.WriteLine("enter num");
	sum += int.Parse(Console.ReadLine());
}
```
___
# do While
```c#
string phone;
do
{
	Console.WriteLine("enter phone num");
	phone = Console.ReadLine();
} while (phone.Length != 11);
```
___
## For 
```c#
int sum=0;
for(int i = 0; i<5 ;i++){
	sum += i;
	Console.WriteLine(sum);// 1 3 6 10 14
}
```
___
# Operators
### Binary Operators
`Var result =firstOperand Operator secondOperand`<br>
`var result  = x + y`<br>
`var result = x* y`<br>
### Unary Operator
`var result = operator onlyOperand`<br>
`var ressult = onlyOperand operator`<br>
`x++;`<br>
`++x;`<br>
### Ternary Operators
`var result = boolean_exp ? value_ifTrue : value_ifFales`<br>
`string result = x>3 ? "Greater than ":"less than or equal"`<br>
### Logical Operator
`|` ==> OR<br>
`&` ==> AND<br>
`^` ==> XOR<br>
___
# Arrays
Arrays are used to store multiple values in a single variable, instead of declaring separate variables for each value.

```c#
int[] arr = new int[5];
arr[0] =1;
arr[1] =2;
arr[2] =3;


int[] arr2 = new int[] { 2, 5, 6, 3, 4 };
int[] arr3= { 2, 5, 6, 3, 4 };

//C# new features

int[] arr4 = [2, 4, 5, 6, 7];
//arr5 will contain 2,3 content of arr2 and arr3
int[] arr5 = [2, 3, .. arr2, .. arr3];
```

```c#
Console.WriteLine("enter number of students");
int numOfStudents= int.Parse(Console.ReadLine());

string[] names = new string[numOfStudents];
for (int i = 0; i < names.Length; i++)
{
	Console.WriteLine("enter student name");
	names[i] = Console.ReadLine();
}
```
Reference :[Arrays](https://www.w3schools.com/cs/cs_arrays.php)
### multidimensional Array
```c#
int[,] arr = new int[5, 4];

int[,] arr2 = new int[5, 4] { { 2, 3, 4, 5 }, { 6, 5, 4, 5 }, { 6, 7, 8, 8 }, { 6, 7, 8, 8 }, { 5, 4, 3, 3 } };

int[,] arr3= { { 2, 3, 4, 5 }, { 6, 5, 4, 5 }, { 6, 7, 8, 8 }, { 6, 7, 8, 8 }, { 5, 4, 3, 3 } };

arr3[1, 3] = 44;

Console.WriteLine(arr3[1, 3] );
```
Self Study :[Jagged array](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays)
___

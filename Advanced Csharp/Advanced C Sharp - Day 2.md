# System.Object

This is the ultimate base class of all .NET classes Every class or struct or type in c# implicitly inherits from `Object` class. Every class inherits for methods from `object` class

- `Equals`
- `GetHashCode`
- `ToString`
- `GetType`
  You Can override three of those you can't override only `GetType` Method it returns the type of your class

```c#
class employee
{
	public int id { get; set; }
	public string name { get; set; }
	public int age { get; set; }

	public employee(int id=0, string name="", int age=0)
	{
	  this.id = id;
	  this.name = name;
	  this.age = age;
	}

	//Here we override the method ToString inherited from object      class
	public override string ToString()
       {
           return $"{id}-{name}";
       }
	 //override the Equal method From Object class
	public override bool Equals(object? obj)
	{
	 employee e = obj as employee;
	 if(e == null) return false;
	 else return (id == e.id && name == e.name && age == e.age);
	 }
	//Override the gethashcode method
	 public override int GetHashCode()
	 {
	 return id;
	 }
	 
   }
```

```c#
static void Main(string[] args){
	employee e1 =new employee();
	//Here it implicitly calls ToString which we override
	Console.WriteLine(e1);
	employee e2 = new employee(1,"ahmed",22);
	bool isEqual = e1.Equals(e2);

}
```

Here we override the three methods in employee class which were inherited from object class

Remember that always your classes inherits from object some times direct like the employee example and sometimes indirect in case your class employee inherits from another class
`Object =>Person => Employee`
if your class employee inherits from person the it can't inherit from two classes at the same time but here person class inherits from object so the employee inherits from object but indirect inheritance.

# Boxing And Unboxing

## Boxing

Boxing is used to store value types in the garbage-collected heap. Boxing is an implicit conversion of a `value type` to the type `object` or to any interface type implemented by this value type. Boxing a value type allocates an object instance on the heap and copies the value into the new object.

```c#
int i = 123;
// Boxing copies the value of i into object o.
object o = i;
```

It is also possible to perform the boxing explicitly but explicit boxing is never required.

## Unboxing

Unboxing is an explicit conversion from the type `object` to a `value type` or from an interface type to a value type that implements the interface. An unboxing operation consists of:

- Checking the object instance to make sure that it is a boxed value of the given value type.
- Copying the value from the instance into the value-type variable.

The following statements demonstrate both boxing and unboxing operations:

```c#
int i = 123;      // a value type
object o = i;     // boxing
int j = (int)o;   // unboxing
```

Reference : [Boxing and Unboxing](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing)

---

# Indexers

- Indexers enable objects to be indexed in a similar manner to arrays.
- A `get` accessor returns a value. A `set` accessor assigns a value.
- The `this` keyword is used to define the indexer.
- The `value` keyword is used to define the value being assigned by the `set` accessor.
- Indexers do not have to be indexed by an integer value; it is up to you how to define the specific look-up mechanism.
- Indexers can be overloaded.
- Indexers can have more than one formal parameter, for example, when accessing a two-dimensional array.

```c#
class Subject {
	public int id {get; set;}
	public string name {get; set;}
	public int duration {get; set;}

	Public Subject(int id,string name ,int duration){
		this.id =id;
		this.name =name ;
		this.duration = duration;
	}
}

class Student {
	public int id {get; set;}
	public string name {get; set;}
	public int age {get; set;}
	public subject[] mySubjects{get; set;}

	public Student(int id,string name ,int age){
		this.id =id;
		this.name =name ;
		this.age = age;
	}

//Defining the indexer to access it like this st["C#"] =25
//here we set the value of subject named "c#" to be 25
//and also can get the value like this st["C#"]

public int this[string subjectName]{
	set{
		for(int i=0;i<mySubjects.Length;i++){
			if(mySubjects[i].name == subjectName)
			mySubjects[i].duration = value;
		}
	}
	get{

	for(int i=0;i<mySubjects.Length;i++){
			if(mySubjects[i].name == subjectName)
			return mySubjects[i].duration;
		}
	}
	   return -1;
}
}

```

**Using Indexer in main**

```C#
 Subject[] subj = new Subject[]
{
	new Subject(1,"C#",22),
	new Subject(2,"js",25), 
	new Subject(4,"angular",22),
	new Subject(3,"mvc",30)
 };
Student s = new Student(2, "ali ahmed", 22, subj);
 //set value of c# to be 35
 s["C#"] = 35;
 //get the value of c#
 Console.WriteLine(s["C#"]);
```

Reference : [Indexers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/)

---

# Exception Handling

## Checked And Unchecked

The `checked` and `unchecked` statements specify the overflow-checking context for integral-type arithmetic operations and conversions. When integer arithmetic overflow occurs, the overflow-checking context defines what happens. In a checked context, a `System.OverflowException` is thrown. 
In an unchecked context, the operation result is truncated by discarding any high-order bits that don't fit in the destination type

```c#
checked{
	int x = int.MaxValue;
	//here checked context throws an overflow exception
	x += 20 ;
	long y = int.MaxValue;
	y +=10;
//here the unchecked does not throw exceptions it turncate the value
	unchecked{
	//z = 9
	int z =(int) y;
	}
}
```

Reference : [Checked and Unchecked](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/checked-and-unchecked)

---

## is , as

### IS

The `is` keyword determines if a conversion from one object type to another is compatible. If the conversion is compatible, it returns true; otherwise, it returns false.

```c#
object obj = new student(1, "ali", 22);
if(obj is student){
Console.WriteLine("Obj is a Student");
}
```

**Another use for Is**
Here if the return is true it casts the `obj` into a `student` and assign the value to `st` otherwise `st` is null

```c#
object obj = new student(1, "ali", 22);
if(obj is student st){
Console.WriteLine("Obj is a Student");
}
```

### as

The term `as` is used to convert from one type to another. The type can be nullable or reference. The `as` keyword determines whether one object type is compatible with another. If the new object type is compatible, it will return its value; otherwise, null will be returned.

```c#
Object obi = new employee();
obj = 1;
//here em = null because it couldn't cast
employee em =new employee();
Console.WriteLine(em);
```

---

## TryParse

The Parse Method can't handle anything other than numbers so if wrong input is passed to `int.Parse` method it throws an exception

```c#
int x= int.Parse(Console.ReadLine());
```

In `int.TryParse` methods it attempts to convert string to integer if it succeed it returns true otherwise it returns false but it does not throw an exception

```c#
int x;
bool status=int.TryParse(Console.ReadLine(), out x);
```

Here the output of parsing if succeeded is out throw x otherwise it returns false to the status

---

## Null Conditional Operator

`?.`
It will return null if the left-hand side expression is evaluated to null instead of throwing an exception (NullReferenceException).  If the left-hand side expression evaluates to a nonnull value then it will be treated as a normal

```c#
public static int? getlenght(int[] arr)
	{
//if the array is null it returns null without throwing an exceptoion
	return arr?.Length;
	}
```

---

## Try Catch Finally

### Try Block

The `try` block encloses the code that may potentially throw an exception. It allows the program to run the enclosed statements and monitors them for errors.

```c#
try {
// Code that may throw an exception
}
```

### Catch Block

The `catch` block is used to handle the exception thrown by the `try` block. It is executed only if an error occurs in the `try` block.

```c#
catch (error) {
  // Handle the error
}
```

### Finally Block

The `finally` block contains code that will be executed regardless of whether an exception is thrown or not. It is typically used for cleaning up resources or executing code that must run no matter what.

```c#
finally {
// Code to be executed after try and catch, regardless of an exception being thrown or not
}
```

```c#
 try
	 {
	 Console.WriteLine("enter number");
	 int n = int.Parse(Console.ReadLine());
	 int z = 100 / n;
	 Console.WriteLine(z);
	 }catch (FormatException ex)
	 {
	 Console.WriteLine("invalid number ");
	}catch(DivideByZeroException ex)
	{
	Console.WriteLine(ex.Message);
	}catch(Exception ex)
	{
	Console.WriteLine("error:inalid input");
	 //logging error
	Console.WriteLine(ex.InnerException);
	 }
	 finally{
	 //release resources
	 }
```

You can put many catch blocks as you want.

---

## Throw exceptions

we use `throw` keyword to explicitly throw an exception

```c#
throw new Exception("Message");
```

---

## User Defined Exception

you can define your own exception by inheriting from `Exception` Class

```c#
class InvalidAgeException : Exception
	{
	public InvalidAgeException(int age)
	:base("invalid age , age must between 6  and 20"){
	}
	}
```

In Student class you can for example use this user defined exception to restrict invalid input

```C#
int age;
public int Age{
	set{
		if(value>6 && value <20){
			age = value;
		}
		else{
		throw new InvalidAgeException(value);
		}
}
get{
	return age;
}
}
```

---

# Enums

An *enumeration type* (or *enum type*) is a value type defined by a set of named constants of the underlying integral numeric type. To define an enumeration type, use the `enum` keyword and specify the names of *enum members*:

Defining an Enumeration

```c#
enum gender
	{
	male,
	female
	}
```

In Main

```c#
gender g = gender.male;
g =gender.female;
```

By default, the associated constant values of enum members are of type `int`; they start with zero and increase by one following the definition text order. You can explicitly specify any other integral numeric type as an underlying type of an enumeration type. You can also explicitly specify the associated constant values

```c#
enum ErrorCode : ushort
{
    None = 0,
    Unknown = 1,
    ConnectionLost = 100,
    OutlierReading = 200
}
```

## Bit Flag

If you want an enumeration type to represent a combination of choices, define enum members for those choices such that an individual choice is a bit field. That is, the associated values of those enum members should be the powers of two.

```c#
[Flags]
enum previlage:byte
	{
	admin=1,
	student=2,
	instractor=4,
	guest=8,
	security=16
	}
```

```c#
previlage p = (previlage)10;
Console.WriteLine(p);//here p equlas student, guest
```

so if the number specified not in the enum choices the flag attribute tries to combine two or more choices to get the result.
Reference: [Enums](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum)

---

# Singleton Design Pattern

Singleton design pattern in C# is one of the most popular design patterns. In this pattern, a class has only one instance in the program that provides a global point of access to it. In other words, a singleton is a class that allows only a single instance of itself to be created and usually gives simple access to that instance.

```c#
 class student{
	 public int id { get; set; }
	 public string name { get; set; }
	 public gender mygen { get; set; }

	student(int id=0 , string name=""  ,gender mygen=gender.male)
	 {
	 this.id =id;
	 this.name =name;
	 this.age=age;
	 }
	static student s = null;
	public static student getstudent()
	{
		if(s ==null)
		s=new student();
		return s;
	} 
public override string ToString()
	{
	return $"{id}-{name}-{mygen}";
	}
    }
```

The class includes a static field `s` and a static method `getstudent` to implement a singleton pattern. This ensures that only one instance of the `student` class is created and reused.

```c#
student s = student.getstudent();
student s2 = student.getstudent();
Console.WriteLine(s.GetHashCode()); Console.WriteLine(s2.GetHashCode());
```

Here you will find that both objects has the same hashcode which means that they are the same object.

---

References: [Files](https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-8.0)

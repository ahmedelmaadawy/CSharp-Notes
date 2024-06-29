# Constructor
Whenever an instance of a `class` or a `struct` is created, its constructor is called. A class or struct may have multiple constructors that take different arguments. Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read. For more information and examples, see Instance constructors and Using constructors.

The preceding actions take place when a new instance is initialized. If a new instance of a `struct` is set to its `default` value, all instance fields are set to 0.

### Syntax
- constructor has no return type
- the name of constructor must be the same as struct name or class name
```c#
public struct ComplexNumber{
	public int Real{set; get;}
	public int Img{set; get;}
	//default constructor
	//this is created by default
	//it sets the values of properties with default values
	//public ComplexNumber(){
	//	Real = 0;
	//	Img = 0;
	//}
	public ComplexNumber(int real ,int img){
		Real =real;
		Img = img;
	}
	public void display(){
		Console.WriteLine($"{Real}+{Img}i")
	}
}
```
Now struct has two constructors the default and the one we defined
```c#
ComplexNumber c = new ComplexNumber();
c.display();//0+0i
ComplexNumber c2 = new ComplexNumber(10,5);
c2.display();//10+5i
```
Reference:[Constructor](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors)
___
# Constructor Overloading
Constructs as the same like methods can be overloaded and all restrictions is also applied to constructor overloading 

If you defined a parameter-less constructor the complier won't create it 
```c#
public struct ComplexNumber{
	public int Real{set; get;}
	public int Img{set; get;}
	public ComplexNumber(){
		Real = 1;
		Img = 1;
	}
	public ComplexNumber(int real ,int img){
		Real =real;
		Img = img;
	}
	public ComplexNumber(int real){
		Real = real;
		Img = 1;
	}
	public void display(){
		Console.WriteLine($"{Real}+{Img}i")
	}
}
```

```c#
ComplexNumber c = new ComplexNumber();
c.display();//1+1i
ComplexNumber c2 = new ComplexNumber(10,5);
c2.display();//10+5i
ComplexNumber c3 = new ComplexNumber(10);
c3.display();//10+1i
```

## Constructor Chaining
_Constructor chaining_ is a technique in _C#_ that allows one constructor to call another constructor of the same class.
It's done by keyword `this`
```c#
public struct ComplexNumber{
	public int Real{set; get;}
	public int Img{set; get;}
	public ComplexNumber(){
		Real = 1;
		Img = 1;
	}
	public ComplexNumber(int real ,int img){
		Real =real;
		Img = img;
	}
	//this instructor will call the constructor that takes two parameters
	public ComplexNumber(int real):this(real ,1)
	{
		
	}
	public void display(){
		Console.WriteLine($"{Real}+{Img}i")
	}
}
```
___
# Class
A type that is defined as a class is a reference type. At run time, when you declare a variable of a reference type, the variable contains the value null until you explicitly create an instance of the class by using the new operator, or assign it an object of a compatible type that may have been created elsewhere

When the object is created, enough memory is allocated on the managed heap for that specific object, and the variable holds only a reference to the location of said object. The memory used by an object is reclaimed by the automatic memory management functionality of the CLR, which is known as _garbage collection_.

**Every thing defined within the struct is the same as class but with a few changes**
- when you define a constructor the compiler won't generate a parameter-less constructor
- you can't use a reference to object until you create instance of the class and assign it to the reference 

### Defining Class
```c#
public class ComplexNumber {

public int Real{set; get;}
	public int Img{set; get;}
	public ComplexNumber(){
		Real = 1;
		Img = 1;
	}
	public ComplexNumber(int real ,int img){
		Real =real;
		Img = img;
	}
	public ComplexNumber(int real):this(real ,1)
	{
		
	}
	public void display(){
		Console.WriteLine($"{Real}+{Img}i")
	}
}
```
#### Creating Object
```c#
ComplexNumber c;//define reference to object 
	//but still can't use it unless you allocate it to object in memory
c =new ComplexNumber();//define object from complex 
```
Reference:[Class](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)
___
### Destructor
Destructors in C# are methods inside the class used to destroy instances of that class when they are no longer needed. The Destructor is called implicitly by the .NET Framework’s Garbage collector and therefore programmer has no control as when to invoke the destructor. An instance variable or an object is eligible for destruction when it is no longer reachable.

Important Points:

- A Destructor is unique to its class i.e. there cannot be more than one destructor in a class.
- A Destructor has no return type and has exactly the same name as the class name (Including the same case).
- It is distinguished apart from a constructor because of the Tilde symbol (~) prefixed to its name.
- A Destructor does not accept any parameters and modifiers.
- It cannot be defined in Structures. It is only used with classes.
- It cannot be overloaded or inherited.
- It is called when the program exits.
- Internally, Destructor called the Finalize method on the base class of object.

```c#
class ComplexNumber{
//your properties
//your methods
~ComplexNumber(){
}
	Console.WriteLine("Finalizing);
}
```
Reference :[Destructor](https://www.geeksforgeeks.org/destructors-in-c-sharp/)
___

# Inheritance
 Inheritance enables you to create new classes that reuse, extend, and modify the behavior defined in other classes. The class whose members are inherited is called the _base class_, and the class that inherits those members is called the _derived class_. A derived class can have only one direct base class. However, inheritance is transitive. If `ClassC` is derived from `ClassB`, and `ClassB` is derived from `ClassA`, `ClassC` inherits the members declared in `ClassB` and `ClassA`.

### Child inheriting from parent
```c#
class Parent {
	public int x {get; set;}

	public void Show(){
		Console.WriteLine($"X:{x}");
	}
}

class Child :Parent{
	public int y{get; set;}
}
```

```c#
Child c = new Child();

c.X =10;
c.Y=5;
//it inherited the method from parent
C.Show();//X:10
```
___
## Method and Property Hiding

```c#
class Parent {
	public int x {get; set;}

	public void Show(){
		Console.WriteLine($"X:{x}");
	}
}

class Child :Parent{
	//here we hide the parent property
	public new string X{set;get;}
	public int y{get; set;}
	//here we want to hide the parent method so we use "new"
	//so when child is calling show it will call this show
	public new void Show(){
		Console.WriteLine($"X:{x} ,Y:{y}");
	}
}
```

```c#
Child c = new Child();

c.X ="hello";
c.Y=5;
C.Show();//X:hello ,Y:5
```
___
#### Calling Method from parent in child
```c#
class Parent {
	public int x {get; set;}

	public void Show(){
		Console.WriteLine($"X:{x}");
	}
}

class Child :Parent{
	//public new string X{set;get;}
	public int y{get; set;}
	
	public new void Show(){
		//this will call the Show() in parent
		base.Show();
		Console.WriteLine($"Y:{y}");
	}
}
```
___
## Inheritance Constructor Chaining 
If parent class has no parameter-less constructor and child child tried do define a constructor it will give error you must call the parameter constructor from child so it will know how to construct the parent 
We use `base` Keyword to call parent constructor

```c#
class Parent {
	public int x {get; set;}

	public Parent(int x){
		X= x;
	}
	public void Show(){
		Console.WriteLine($"X:{x}");
	}
}

class Child :Parent{
	public int y{get; set;}
	public Child ():base(0){
		y=0;
	}
	public Child(int x , int y):base(x){
		Y = y;
	}
	public new void Show(){
		//this will call the Show() in parent
		base.Show();
		Console.WriteLine($"Y:{y}");
	}
}
```
___
# Virtual Method And Override Keyword
In C#, a virtual method is a method that can be overridden in a derived class. When a method is declared as virtual in a base class, it allows a derived class to provide its own implementation of the method.

when a reference of parent is assigned to instance of child here the reference only can access and invoke the methods inside the parent class 

```c#
class Parent {
	public int x {get; set;}

	public Parent(int x){
		X= x;
	}
	public void Show(){
		Console.WriteLine($"X:{x}");
	}
}

class Child :Parent{
	public int y{get; set;}
	public Child ():base(0){
		y=0;
	}
	public Child(int x , int y):base(x){
		Y = y;
	}
	public new void Show(){
		//this will call the Show() in parent
		base.Show();
		Console.WriteLine($"Y:{y}");
	}
}
```

Here we will assign a child object to a parent reference 
```c#
Parent obj = new Child(10,10);
//because obj is a reference of Parent 
//it only can access the members and functions from Parent 
//and Beacuse Parent is a part of child it can reference to it
obj.Show();//X:10
```

we want to modify this behavior and when a reference is from parent is assigned to  child object it will call the method from child we can do this with the `virtual` and `Override` keyword

```c#
class Parent {
	public int x {get; set;}

	public Parent(int x){
		X= x;
	}
	//here we extend the virtuality
	public virtual void Show(){
		Console.WriteLine($"X:{x}");
	}
}

class Child :Parent{
	public int y{get; set;}
	public Child ():base(0){
		y=0;
	}
	public Child(int x , int y):base(x){
		Y = y;
	}
	//you can't override a method without the parent extends virtality
	public override void Show(){
		base.Show();
		Console.WriteLine($"Y:{y}");
	}
}
```

```c#
Parent obj = new Child(10,10);
//the child method overrides the parent so it calls the method inside the child
obj.Show();//X:10
		   //Y:10
```
___
# Abstract Class

In C#, an abstract class is a class that cannot be instantiated. Instead, it serves as a base class for other classes to inherit from. Abstract classes are used to define a common set of behaviors or properties that derived classes should have.

Abstraction in C# is the process to hide the internal details and show only the functionality. The abstract modifier indicates the incomplete implementation. The keyword abstract is used before the class or method to declare the class or method as abstract. Also, the abstract modifier can be used with indexers, events, and properties. 

**Abstract Class:** This is the way to achieve the abstraction in C#. An Abstract class is never intended to be instantiated directly. An abstract class can also be created without any abstract methods, We can mark a class abstract even if doesn’t have any abstract method. The Abstract classes are typically used to define a base class in the _class hierarchy_. Or in other words, an abstract class is an incomplete class or a special class we can’t be instantiated. The purpose of an abstract class is to provide a blueprint for derived classes and set some rules that the derived classes must implement when they inherit an abstract class. We can use an abstract class as a base class and all derived classes must implement abstract definitions.

**Abstract Method:** A method that is declared abstract, has no “body” and is declared inside the abstract class only. An abstract method must be implemented in all non-abstract classes using the override keyword. After overriding, the abstract method is in the non-Abstract class. We can derive this class in another class, and again we can override the same abstract method with it.

To create an abstract class in C#, you use the “abstract” keyword before the class definition.
```c#
abstract class AreaClass
{
	abstract public int Area();
}

class Square : AreaClass
{
	int side = 0;
	public Square(int n)
	{
		side = n;
	}
	public override int Area()
	{
		return side * side;
	}
}
```

In Main
```c#
Square s = new Square(6);
Console.WriteLine("Area = " + s.Area());
```
#### Another Example
```C#
public abstract class Animal
{
	public abstract string Sound { get; }
	public virtual void Move()
	{
		Console.WriteLine("Moving...");
	}
}

public class Cat : Animal
{
	public override string Sound => "Meow";
	public override void Move()
	{
		Console.WriteLine("Walking like a cat...");
	}
}

public class Dog : Animal
{
	public override string Sound => "Woof";
	public override void Move()
	{
		Console.WriteLine("Running like a dog...");
	}
}
```
In Main
```c#
Animal[] animals = new Animal[] { new Cat(), new Dog() };
foreach (Animal animal in animals)
{
	Console.WriteLine($"The {animal.GetType().Name} goes {animal.Sound}");
	animal.Move();
}
```
Reference:[Abstract](https://www.geeksforgeeks.org/c-sharp-abstract-classes/)
___
# Sealed Class

Sealed classes are used to restrict the users from inheriting the class. A class can be sealed by using the _**sealed**_ keyword. The keyword tells the compiler that the class is sealed, and therefore, cannot be extended. No class can be derived from a sealed class.

_A method can also be sealed_, and in that case, the method cannot be overridden. However, a method can be sealed in the classes in which they have been inherited. If you want to declare a method as sealed, then it has to be declared as **virtual** in its base class.

```c#
sealed class SealedClass {
	// Calling Function
	public int Add(int a, int b)
	{
		return a + b;
	}
}
```
___
# Static

A static class is basically the same as a non-static class, but there's one difference: a static class can't be instantiated. In other words, you can't use the new operator to create a variable of the class type. Because there's no instance variable, you access the members of a static class by using the class name itself.

## Static Members
A non-static class can contain static methods, fields, properties, or events. The static member is callable on a class even when no instance of the class exists. The static member is always accessed by the class name, not the instance name. Only one copy of a static member exists, regardless of how many instances of the class are created. Static methods and properties can't access non-static fields and events in their containing type, and they can't access an instance variable of any object unless it's explicitly passed in a method parameter.

```C#
class Student{
	public int id{set; get;}
	public string name {set; get;}
	public int age{set; get;}
	//this is static variable its the same for all objects
	public static int count=0;
	public Student(string name,int age){
		this.name = name;
		this.age =age ;
		count++;
		this.id = count;
	
	}
	puplic string display(){
		return $"{id}-{name}-{age}";
	}
}
```

in main
```C#
Student s1 = new Student("ahmed",22);
Student s2 = new Student("salem",23);
Console.WriteLine(s1.display());//1-ahmed-22
Console.WriteLine(s2.display())//2-salem-23
//you can access static variables with class name
Console.WriteLine(Student.count);
```
## Static Constructor
static constructor is only used to give initial values to static members 
- Static constructor in not public 
- can't be overloaded
- Can't take parameters
- must have `static` keyword
- does not affect any excitation


```c#
Class Student{
public int id{set; get;}
	public string name {set; get;}
	public int age{set; get;}
	//this is static variable its the same for all objects
	public static int count;
	static Student(){
		count = 0;
	}
	public Student(string name,int age){
		this.name = name;
		this.age =age ;
		count++;
		this.id = count;
	
	}
	puplic string display(){
		return $"{id}-{name}-{age}";
	}

}
```
___
## Static Methods

Static methods are like static variables can use it without creating object from class
```c#
class Operation {
	public static int Sum (int x, int y){
		return x+y ;
	}
}
```
Main
```c#
int result = Operation.Sum(10,20);
Console.WriteLine(result);//30
```
___
## Static Class
Is a Class that can't have member that are not static 
- can't create object from static class
- all members and functions are static
- can't inherit and can't be inherited
___
# Operator Overloading

```c#
struct complexnum{
	public int real {get;set;}
	public int img {get; set;}
	
	public complexnum( int real , int img)
	{
		this.real = real ;
		this.img = img ;
	}
	public string getstring()
	{
		return $"{real}+{img}i";
	}
	public static complexnum operator +(complexnum c1 , complexnum c2)
	{
		return new complexnum(c1.real + c2.real, c1.img + c2.img);
	}
	public static complexnum operator ++(complexnum c1)
	{
		c1.real++;
		return c1;
	}
	public static bool operator >(complexnum c1, complexnum c2)
	{
		return c1.real > c2.real;
	}
	public static bool operator <(complexnum c1, complexnum c2)
	{
		return c1.real < c2.real;
	}
	public static bool operator ==(complexnum c1, complexnum c2)
	{
		return (c1.real == c2.real&& c1.img==c2.img);
	}
	public static bool operator !=(complexnum c1, complexnum c2)
	{
		return (c1.real != c2.real || c1.img != c2.img);
	}
	public static explicit operator int (complexnum c1)
	{
		return c1.real;
	}
	public static implicit operator float(complexnum c1)
	{
		return c1.real+(c1.img*0.1F);
	}
}
```

```c#
complexnum c1 = new complexnum(3, 4);
complexnum c2 = new complexnum(4, 5);
complexnum c3 = c1 + c2;
c3 += c1;
Console.WriteLine(c3.getstring());//10+13i
c3++;//11+13i
if (c1 > c2)
{
//some logic
}
```

 ```c#
complexnum c1 = new complexnum(3, 4);
int x = (int)c1;
Console.WriteLine(x);

float y = c1;
Console.WriteLine(y);
```
Reference:[Operator overloading](https://www.geeksforgeeks.org/c-sharp-operator-overloading/)
___
# Access Modifiers

Assembly Means the same project or the same `.dll` 

| Caller's location                      | `public` | `protected internal` | `protected` | `internal` | `private protected` | `private` |
| -------------------------------------- | -------- | -------------------- | ----------- | ---------- | ------------------- | --------- |
| Within the file                        | ✔️️      | ✔️                   | ✔️          | ✔️         | ✔️                  | ✔️        |
| Within the class                       | ✔️️      | ✔️                   | ✔️          | ✔️         | ✔️                  | ✔️        |
| Derived class (same assembly)          | ✔️       | ✔️                   | ✔️          | ✔️         | ✔️                  | ❌         |
| Non-derived class (same assembly)      | ✔️       | ✔️                   | ❌           | ✔️         | ❌                   | ❌         |
| Derived class (different assembly)     | ✔️       | ✔️                   | ✔️          | ❌          | ❌                   | ❌         |
| Non-derived class (different assembly) | ✔️       | ❌                    | ❌           | ❌          | ❌                   | ❌         |

___

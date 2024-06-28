# Generic
Generics introduces the concept of type parameters to .NET. Generics make it possible to design classes and methods that defer the specification of one or more type parameters until you use the class or method in your code. For example, by using a generic type parameter `T`, you can write a single class that other client code can use without incurring the cost or risk of runtime casts or boxing operations.
## Generic Methods

```csharp
class Operation{
public static void Swap<T>(ref T x,ref T y){
	T temp = x;
	x = y;
	y = temp;
	}
}
```
Using Generic swap in main 
```c#
int a =5,b =7;
//swaps int a and b
Opertation.Swap<int>(ref a,ref b);
Console.WriteLine($"a={a},b={b}");
string name1 ="ali",name2="mohamed"
Operation.swap<string>(ref name1,ref name2);
Console.WriteLine($"name1: {name1},name2: {name2}");
```

So you can use the same method with different datatypes
___
## Generic Class

```c# 
class Stack<T>
{
	T[] arr;
	int tos;//Top Of Stack
	public Stack(int size =10){
		arr = new T[size];
		tos = -1;
	}
	public void push(T item){
	if(tos <arr.Length -1){
		arr[++tos]=item;
		}
	}
	public T pop(){
	if(tos > -1)
		return arr[tos--];
	else
		return default(T);
	}
}
```

Using Generic Stack in Main 
```c#
Stack<int> s1 = new Stack<int>(5);
s1.push(1);
s1.push(5);
s1.push(3);
// 3
Console.WriteLine(s1.pop());
//5
Console.WriteLine(s1.pop());
//1
Console.WriteLine(s1.pop());

Stack<string> strs =new Stack<string>(5);
strs.push("ahmed");
strs.push("mohamed");
strs.push("salem");
//salem
Console.WriteLine(strs.pop());
//mohamed
Console.WriteLine(strs.pop());
//ahmed
Console.WriteLine(strs.pop());
```

____
### Generic Constraints
Constraints inform the compiler about the capabilities a type argument must have. Without any constraints, the type argument could be any type. The compiler can only assume the members of System.Object , which is the ultimate base class for any .NET type. For more information, see Why use constraints. If client code uses a type that doesn't satisfy a constraint, the compiler issues an error.Constraints are specified by using the `where` contextual keyword.

Examples:
`where T : struct`
`where T : class`

See Reference : [generic Constraints](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)
___
# Interface
An **interface** in C# is a contract that defines a set of methods, properties, events, and indexers that a class or struct must implement. Interfaces cannot be instantiated directly, but they can be implemented by classes and structs. They are one of several tools for implementing object-oriented design in C#.

```c#
// Create an interface called IAnimal

interface IAnimal
{
// Define a method called Speak()
    void Speak();
}
// Create a class called Dog that implements the IAnimal interface

class Dog : IAnimal

{
    public void Speak()
    {
        Console.WriteLine("Woof!");
    }
}
// Create a class called Cat that implements the IAnimal interface
class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Meow!");
    }
}
class operation{

public static void animalSound(IAnimal animal){
	animal.Speak();
	}
}
public class Program

{

    public static void Main(string[] args)

    {
    //Woof!
    operation.animalSound(new Dog());
    //Meow!
    operation.animalSound(new Cat());
    }
    
}
```
Here in this example we didn't have to define multiple methods for every type `dog` `cat` we only implemented the `IAnimal` interface and used it in the parameter of the method so we let the complier know that it will be passed in here a type that implements the `IAnimal` interface and we used the same methods with different types but they all implement the `IAnimal` Interface.   

Interfaces can be used in C# to achieve a number of different goals, including:

- `Abstraction`: Interfaces can be used to abstract away the implementation details of a class or struct. This can make code more modular and easier to understand.
- `Multiple inheritance`: C# does not support multiple inheritance of classes, but it does support multiple inheritance of interfaces. This allows a class to inherit the functionality of multiple different interfaces.
- `Plug-and-play`: Interfaces can be used to create a “plug-and-play” architecture. This means that different classes or structs can be easily swapped in and out, as long as they implement the same interfaces.
___
## Built-In Interfaces
### IComparable
This interface is implemented by types whose values can be ordered or sorted. It requires that implementing types define a single method,`CompareTo(Object)`, that indicates whether the position of the current instance in the sort order is before, after, or the same as a second object of the same type. The instance's IComparable implementation is called automatically by methods such as `Array.Sort` and `ArrayList.Sort`.

```c#
class student:IComparable<student>
{
public int id { get; set; }
public string name { get; set; }
public int age { get; set; }
	public student(int id, string name, int age)
	  {
		this.id = id;
		this.name = name;
		this.age = age;
		}
	 public override string ToString()
	   {
	    return $"{id}-{name}-{age}";
		}
	 public int CompareTo(student? other)
	   {
	 return age.CompareTo(other.age);
	    }
 }
```

In Main 
```c#
student[] arr = new student[]{
	new student(4,"mostafa",22),
	new student(3,"mona",25),
	new student(2,"ola",23),
	new student(1,"mohamed",21),
};
//sort array based on age
Array.Sort(arr);
```
___
# Collections
C# collections are made to more effectively organize, store, and modify comparable data. Adding, deleting, discovering, and inserting data into the collection are all examples of data manipulation. These classes support stacks, queues, lists, and hash tables. Most collection classes implement the same interfaces.
### Foreach
```c#
int[] arr = { 3, 4, 1, 4, 5, 6 };
foreach(int item in arr)
{
  Console.WriteLine(item);
}
```
### Non-Generic Collection
Non-generic collections are specialized data storage and retrieval classes that handle stacks, queues, lists, and hash tables. The `System.Collections` namespace contains the Non-generic Collection classes. Non-generic collections store elements in `object` arrays internally, allowing them to hold any data type.
#### Types of Non-Generic Collection
- `ArrayList`
- `sortedlist`
- `hashset`
- `queue`
- `stack`
```c#
ArrayList li = new ArrayList() {44,89,33,4 };
li.Add(2);
li.Add(8);
li.Add("ali");
//the index 3 has an aray of integer
li.Add(new int[] { 99, 55, 66, 54 });
//here after index 3 each item in the array will be in seperate index
li.AddRange(new int[] { 99, 55 ,44,55,66,66,44});
//this is just for modufy can't use it to assign to new index
li[2] = 6;

//FINDS THE FIRST 55 ELEMENT AND DELETE IT
li.Remove(55);
//remeve the item in index 6
li.RemoveAt(6);
//start from index 2 remove 3 items
li.RemoveRange(2, 3);


/*Looping in arraylist*/
foreach (object o in li)
{
   Console.WriteLine(o);
}

```

Reference : [ArrayList](https://learn.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=net-8.0)
___
## Generic Collection
A Generic collection provides the type safety without derivation from a basic collection type and the implementation of type-specific members. The Generic Collection classes are found in the namespace `System.Collections.Generics.` Internally, Generic Collections store elements in arrays of their respective types.
### Types of generic collection
- `List`
- `sortedList`
- `Dictionary`
- `Queue`
- `Stack`
#### List
In Generic List, we have to specify a data type to its contents, and all elements will have the same datatype.
```c#
List<int> li = new List<int>() { 55,44,33};
li.Add(2);
li.Add(4);
li.Add(8);

li[0]++;

foreach(int i in li)
{
   Console.WriteLine(i);
}
```

#### Dictionary
Dictionaries usually store data in key-value pairs, and we have to specify both data types beforehand.
```c#
Dictionary<string, int> StudentAge = 
						new Dictionary<int, string>();

StudentAge.Add("Ahmed",22);
StudentAge.Add("Mohamed",20);
StudentAge.Add("Ali",25);
StudentAge.Add("Salem",30);
StudentAge.Add("Salwa",25);

//update a value
StudentAge["ahmed"] = 20;

//remove element
StudentAge.Remove("Mohamed");
//access dictionary
foreach(KeyValuePair<string ,int> student in StudentAge)
	{
	Console.WriteLine(student.Key);
	Console.WriteLine(student.Value);
	Console.WriteLine("------------");
	}

//you can also use this way to access key or values
foreach (string name in StudentAge.Keys)
	{
	  Console.WriteLine(name);
	}
foreach (string age in StudentAge.Keys)
	{
	  Console.WriteLine(age);
	}

```
___
###  null-coalescing operators
` return a ?? b;`
this means that if a is `null` then return b instead if a is not null return a it replaces this bloc of code
```c#
//return a ?? b;
//these two are the same result
if(a == null)
	return a;
else 
	return b;
```

`txt ?? = "Hello"; `
this means that if txt is null then assign "Hello" to txt 
```c#
string txt = null;
txt ??= "hi";
Console.WriteLine(txt); //here txt = "hi"
```
___

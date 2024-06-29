# Struct
Structs  represent data structures that can contain data members and function members. However, unlike classes, structs are value types and do not require heap allocation. A variable of a `struct` type directly contains the data of the `struct`, whereas a variable of a class type contains a reference to the data, the latter known as an object.

> _Note_: Structs are particularly useful for small data structures that have value semantics. Complex numbers, points in a coordinate system, or key-value pairs in a dictionary are all good examples of structs. Key to these data structures is that they have few data members, that they do not require use of inheritance or reference semantics, rather they can be conveniently implemented using value semantics where assignment copies the value instead of the reference. _end note_>

#### Defining Struct
```csharp
struct ComplexNumber{
	// Members
	public int real;
	public int img;
	
}
```
#### variable from struct in main
```csharp
ComplexNumber c = new ComplexNumber() ;// real =0 img =0(defaults)
c.real = 10;
c.img = 2;
Console.WriteLine($"{c.real} + {c.img} i");
```
**here is a major problem the members of our struct are public so they can be changed without validation or restriction so we have to use the `property`.

## Property in struct
```c#
struct ComplexNumber{
	//private Members
	int real;
	int img;
	//proberties to access members and add validation
	public int Real{
		set{
			//validate on the value before assign it to the member
			if(value >0)
				real =value;
			else
				real =0;
		}
		get{
		//in main when you type "c.Real" returns value of real 
		return real;
		}
	}
	public int Img{
		set{
			//validate on the value before assign it to the member
			if(value >0)
				img =value;
			else
				img =0;
		}
		get{
		//in main when you type "c.Img" returns value of img 
		return img;
		}
	}
}
```

```c#
ComplexNumber c = new ComplexNumber();
c.Real = 10;
c.Img=-10;
Console.WriteLine($"{c.Real}+{c.Img}i"); //10+0i
```
___
## Automatic Property
If we don't need validation over our members we can define dynamic property without defining the private member but compiler will generate the private member and setter and getter after compilation
```c#
struct ComplexNumber{
	public int Real{set;get;}
	public int Img{set;get;}
}
```
___
## Operation in struct
```c#
struct ComplexNumber{
	//private members
	//properties or automatic property

	// operation or methods
	public string display(){
		return $"{real}+{img}i";
	}
}
```

You can call methods inside struct with object name
```c#
ComplexNumber c = new ComplexNumber();
c.Real = 10;
c.Img = 7 ;

Console.writeLine(c.display());//10+7i
```
# Method Overloading

_**Method Overloading**_ is the common way of implementing polymorphism. It is the ability to redefine a function in more than one form. A user can implement function overloading by defining two or more functions in a class or struct sharing the same name. C# can distinguish the methods with **different method signatures**. i.e. the methods can have the same name but with different parameters list (i.e. the number of the parameters, order of the parameters, and data types of the parameters) within the same class. 

- Overloaded methods are differentiated based on the number and type of the parameters passed as arguments to the methods.
- You can not define more than one method with the same name, Order and the type of the arguments. It would be compiler error.
- The compiler does not consider the return type while differentiating the overloaded method. But you cannot declare two methods with the same signature and different return type. It will throw a compile-time error. If both methods have the same parameter types, but different return type, then it is not possible.

**Why do we need Method Overloading?**

If we need to do the same kind of the operation in different ways i.e. for different inputs. In the example described below, we are doing the addition operation for different inputs. It is hard to find many different meaningful names for single action.

**Different ways of doing overloading methods-**   
Method overloading can be done by changing:  

1. The number of parameters in two methods.
2. The data types of the parameters of methods.
3. The Order of the parameters of methods.

### Example
```c#
struct Operation{
	public int sum(int x,int y){
		return x+y;
	}
	public int sum(int x, int y ,int z)
	{
		return x + y+z;
	}
	public float sum(float x , float y)
	{
		return x + y;
	}
}
```

In Main 
```c#
Operation op;
Console.WriteLine(op.sum(2, 3)) ; // 5
Console.WriteLine(op.sum(2.2F, 3.5F)) ; //5.7
Console.WriteLine(op.sum(3,5,7)) ; //15
```

Reference :[Method Overloading](https://www.geeksforgeeks.org/c-sharp-method-overloading/)
___

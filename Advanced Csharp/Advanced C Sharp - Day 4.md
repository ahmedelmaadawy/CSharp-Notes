# Delegates
A delegate is a type that represents references to methods with a particular parameter list and return type. When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type. You can invoke (or call) the method through the delegate instance.
## User Defined Delegate
### Declaration

```c#
public delegate int PerformCalculation(int x, int y);
```
Any method from any accessible class or struct that matches the delegate type can be assigned to the delegate. The method can be either static or an instance method. This flexibility means you can programmatically change method calls, or plug new code into existing classes.

**A method must have the same return type as the delegate.**   
### Assign to delegate
*we will use this class as example for functions to next sections*
```c#
class Calculation {
public static int sum(int x,int y){
return x+y;
}
public static int sub(int x,int y){
return x+y;
}
public static int mult(int x,int y){
return x+y;
}
public static int divide(int x,int y){
return x+y;
}
}
```

```c#
//assign a function to delegate or a pointer to sum function
PerformCalculation calcDelegate =
	new calcDelegate(Calculation.sum);

//These two are equal
PerformCalculation calcDelegate = Calculation.sum
```
### Invoke Delegate
```c#
int result = calcDelegate.Invoke(1,2);
Console.WriteLine(result);//3
//you can use this way also to invoke
result = calcDelegate(3,2);
Console.WriteLine(result);//5
```
### Delegate as a parameter
```c#
//we defined as a parameter a delegate that takes two ints and return int
static void Calc (int x,int y,PerformCalculation calcDel){
	Console.WriteLine(calcDel(x,y));
}
```

```c#
calc(20,10,Calculation.divide); //it will print 2
calc(10,10,Calculation.mult); //it will print 100

```
___
## Multi-Casting Delegate
A useful property of delegate objects is that multiple objects can be assigned to one delegate instance by using the `+` operator. The multicast delegate contains a list of the assigned delegates. When the multicast delegate is called, it invokes the delegates in the list, in order. Only delegates of the same type can be combined.

The `-` operator can be used to remove a component delegate from a multicast delegate.

```c#
//declare a delegate
PerformCalculation calcdel = Calculation.sum;
//add another reference to the delegate
PerformCalculation calcdel += Calculation.sub;
//he will invoke the two functions but only return the last one
Console.WriteLine(calcdel(10,2));//print 8
//How many references in delegate
Console.WriteLine(calcdel.GetInvocationList().Length);//print 2
```
___
## Anonymous Method
Method without a Name to assign to a delegate
```c#
PerformCalculation calcdel = delegate (int x,int y){
		return x+y;
	}
Console.WriteLine(calcdel(2,3));//print 5
```

```c#
//this is a method we defined earlier
//that takes delegate as a parameter
static void Calc (int x,int y,PerformCalculation calcDel){
	Console.WriteLine(calcDel(x,y));
}
```
We Can pass anonymous function instead of defining one to pass 
```c#
calc(100,20,delegate(int x,int y){return x/y}); //print 5  
```
### Lambda Expression
You use a _lambda expression_ to create an anonymous function. Use the lambda declaration operator `=>` to separate the lambda's parameter list from its body.
```c#
calc(100,20,delegate(int x,int y){return x/y}); //print 5 
//these three methods are the same output
calc(100,20,( x,y)=> x/y); //print 5  
calc(100,20,( x,y)=> {return x/y;}); //print 5  


```

___
## Built-in Delegate
### Func
This delegate must return
The return type of this delegate is the last in the definition
```c#
//this is delegate take int and int in parameters and return int
Func<int,int,int> calc = Calculation.sum;
```
### Action
Its a delegate with no return type
This is action that takes int and int in parameters and has no return
`Action<int,int>`
___
# Events
Events enable a class or object to notify other classes or objects when something of interest occurs. The class that sends (or _raises_) the event is called the _publisher_ and the classes that receive (or _handle_) the event are called _subscribers_.

**Events have the following properties:**
- The publisher determines when an event is raised; the subscribers determine what action is taken in response to the event.
- An event can have multiple subscribers. A subscriber can handle multiple events from multiple publishers.
- Events that have no subscribers are never raised.
- Events are typically used to signal user actions such as button clicks or menu selections in graphical user interfaces.
Event are mainly for encapsulation to prevent subscribers to delete from delegate any thing other than their functions or remove all functions from delegate it only allows subscribers to add or remove their own function `event` keyword add restrictions to delegates 
#### Publisher
1) `Define Delegate`
2) `Define Event`
3) `Fire Event "Invoke"`

```c#
//1- define delegate
public delegate void myDel(Button btn)
public class Button{
	public string Value{get; set;}
	//2-Define Event
	public event myDel Click;

	public Button(string value="Button"){
		this.Value = value;
	}
	//3-Fire Event
	public void OnClick (){
	// to prevent null reference exception
	// if their is no subscribers
	if(Click!=null)
		//invoke 
		Click(this);
	}
}
```

#### Subscriber
1) `Define function =>delegate signature`
2) `subscribe event => event += function`
```c#
public class Page{
	public string Name {get;set;}
	public Page(string name="Page"){
		this.Name =name;
	}
	//define function to delegate signature
	public void display(Button btn){
		Console.WriteLine(btn.Value +"Clicked on"+Name+" Page");
	}
}
```

```c#
public static void Main(){
	Button btn = new Button("Form");
	Page p = new Page("Home");
	//subscribe to button event
	btn.Click += p.display;
	//firing or raising the event
	//it will print "Form Clicked on Home Page"
	btn.OnClick();
	Page p2 = new Page("Login");
	//another subscriber
	btn.Click += p2.display;
	//firing or raising the event
	//it will print "Form Clicked on Home Page"
	//              "Form Clicked on Login Page"
	btn.OnClick();
}
```

Reference :[Event Handler](https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler-1?view=net-8.0)
___

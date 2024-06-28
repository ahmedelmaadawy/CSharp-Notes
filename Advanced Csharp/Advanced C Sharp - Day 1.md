# Passing Parameters
## Pass Value Types By Value 

```c#
class Operation {
	public static void swap(int x, int y){
		int temp =x ;
		x = y ;
		y = temp ;
	}
}
```

```c#
int a = 5 ,b = 6 ;
Operation.swap(a,b);
Console.WriteLine($"a={a},b={b}");
```
Here when we call the swap function and pass a and b the values after swap stills the same because when we pass a value type variable in function it only takes copy of the data it doesn't change in the actual variables only the copies inside the functions swap but it's not reflected in the variables `a` and `b`

___
## Passing Value Types By Reference 
```c#
class Operation {
	public static void swap(ref int x,ref int y){
		int temp =x ;
		x = y ;
		y = temp ;
	}
}
```

```c#
int a = 5 ,b = 6 ;
Operation.swap(a,b);
Console.WriteLine($"a={a},b={b}");
```
Here the `ref` Keyword tells the functions that it excepts reference to integer  not the actual value of the integer so when the references is passed to the function it changes the values of the variable that their references passed to the function so the actual `a` and `b` variables change 
___
## Pass Reference type by value

```c#
public static void swap(int[]arr1,int[]arr2){
	int[] temp = arr1;
	arr1 =arr2 ;
	arr2 = temp;
}
```

```c#
int[] arr1 = {1,2,3,4,5};
int[] arr2 = {6,7,8,9,10};

Operation.swap(arr1,arr2);
Console.writeLine(arr1[0]);//1
Console.writeLine(arr2[0]);//6

```
That happened because we only swap references inside the swap function but if we change any content inside any if the references it would affect in the actual array 
Example
```c#
public static void doubleArray(int [] arr){
foreact(int i in arr){
	i*=2;
}
}
```

```c#
int[] arr = {1,2,3,4,5};
Operation.doubleArray(arr);
//the actual values inside the array are doubled
Console.writeLine(arr[0]);//2
```
___
## Pass Reference by Reference
If we want to swap two reference type 
```c#
public static void swap(ref int[]arr1,ref int[]arr2){
	int[] temp = arr1;
	arr1 =arr2 ;
	arr2 = temp;
}
```

```c#
int[] arr1 = {1,2,3,4,5};
int[] arr2 = {6,7,8,9,10};

Operation.swap(ref arr1,ref arr2);
Console.writeLine(arr1[0]);//6
Console.writeLine(arr2[0]);//1

```

Here we swapped the actual reference inside the swap function
___
## Out Keyword
You can use the `out` keyword As a parameter modifier, which lets you pass an argument to a method by reference rather than by value.
The `out` keyword is especially useful when a method needs to return more than one value since more than one `out` parameter can be used .

```c#
public static int calculator(int x ,int y,out int mul ,out int divide,out int sub){
mul =x*y;
divide =x/y;
sub = x-y;
return x+y;
}
```

```c#
int sum,sub,mul,div;
sum = Opertation.Calculator(20,10,out mul,out div,out sub);
/*
	sum = 30 ;
	mul = 200;
	div = 2;
	sub = 10;
*/
```
___
### Difference between Ref and Out
| ref keyword                                                                                                                    | out keyword                                                                                      |
| ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------ |
| It is necessary the parameters should initialize before it pass to ref.                                                        | It is not necessary to initialize parameters before it pass to out.                              |
| It is not necessary to initialize the value of a parameter before returning to the calling method.                             | It is necessary to initialize the value of a parameter before returning to the calling method.   |
| The passing of value through ref parameter is useful when the called method also need to change the value of passed parameter. | The declaring of parameter through out parameter is useful when a method return multiple values. |
| When ref keyword is used the data may pass in bi-directional.                                                                  | When out keyword is used the data only passed in unidirectional.                                 |
___

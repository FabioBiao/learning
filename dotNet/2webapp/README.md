# create webapi
dotnet new webapi -f net6.0

- Controllers/	Contains classes with public methods exposed as HTTP endpoints
- Program.cs	Configures services and the app's HTTP request pipeline, and contains the app's managed entry point
- ContosoPizza.csproj	Contains configuration metadata for the project

# run project
- dotnet run

to check API:
https://localhost:7264/weatherforecast


# make api calls

- install package
dotnet tool install -g Microsoft.dotnet-httprepl

- trust localhost https
dotnet dev-certs https --trust

- Connect to the web API by running the following command:
httprepl https://localhost:{PORT}
httprepl https://localhost:7264  | connect https://localhost:7264

ls
cd Pizza
ls
get
get 1
post -c "{"name":"Hawaii", "isGlutenFree":false}"
put 3 -c  "{"id": 3, "name":"Hawaiian", "isGlutenFree":false}"
get 3 
delete 3 

# create folder
mkdir Models

# data types
- string for words, phrases, or any alphanumeric data for presentation, - not calculation
- char for a single alphanumeric character
- int for a whole number
- decimal for a number with a decimal
- bool for a true/false value

string test;
char userOption;
int gameScore;
decimal particlesPerMillion;
bool processedCustomer;

# var keyword, which instructs the C# compiler to infer the type.
var message = "Hello world!";

# performing basic string formats in .net
Console.WriteLine("Hello\nWorld!");

Console.WriteLine("Generating invoices for customer \"ABC Corp\" ...\n");
Console.WriteLine("Invoice: 1021\t\tComplete!");
Console.WriteLine("Invoice: 1022\t\tComplete!");
Console.WriteLine("\nOutput Directory:\t");
Console.Write(@"c:\invoices");

# string concat
string firstName = "Bob";
string greeting = "Hello";
string message = greeting + " " + firstName + "!";
Console.WriteLine(message);

# string interpolation
string firstName = "Bob";
string message = $"Hello {firstName}!";
Console.WriteLine(message);

# stateful methods vs stateless methods
- stateful methods are built in such a way that they rely on values stored in memory by previous lines of code that have already executed. Or
- Stateful (instance) methods keep track of their state in fields, which are variables defined on the class. Each new instance of the class gets its own copy of those fields in which to store state.

- stateless methods are implemented so that they can work without referencing or changing any values already stored in memory

- object is a instance of a class
- The .NET Class Library contains definitions for data types used in C#.

# arrays

```console
string[] fraudulentOrderIDs = new string[3];

fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
// fraudulentOrderIDs[3] = "D000";

Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "F000";

Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");

string[] names = { "Bob", "Conrad", "Grant" };
foreach (string name in names)
{
    Console.WriteLine(name);
}

int[] inventory = { 200, 450, 700, 175, 250 };
int sum = 0;
foreach (int items in inventory)
{
    sum += items;
}
```

- Initilize a emtpy array
String[] arr = new String[]{}; // declare an empty array
- initialize a list
List<String> list = new List<String>();

list.Add("Hello");
list.Add("world");
list.Add("!");

Console.WriteLine(list[2]);

# Variable names 
Should be camelCase

example:
char userOption;
int gameScore;
float particlesPerMillion;
bool processedCustomer;


```console
/*
   This code reverses a message, counts the number of times 
   a particular character appears, then prints the results
   to the console window.
 */

string originalMessage = "The quick brown fox jumps over the lazy dog.";

char[] message = originalMessage.ToCharArray();
Array.Reverse(message);

int letterCount = 0;

foreach (char letter in message)
{
    if (letter == 'o')
    {
        letterCount++;
    }
}

string newMessage = new String(message);

Console.WriteLine(newMessage);
Console.WriteLine($"'o' appears {letterCount} times.");
```

# data types
```console

Console.WriteLine("Signed integral types:");

Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
```

# data type casting and conversion
```console
decimal myDecimal = 3.14m;
Console.WriteLine($"decimal: {myDecimal}");

int myInt = (int)myDecimal;
Console.WriteLine($"int: {myInt}");
```

```console
decimal myDecimal = 1.23456789m;
float myFloat = (float)myDecimal;

Console.WriteLine($"Decimal: {myDecimal}");
Console.WriteLine($"Float: {myFloat}");
```

```console
int first = 5;
int second = 7;
string message = first.ToString() + second.ToString();
Console.WriteLine(message); = 57
```

```console
string[] values = { "12.3", "45", "ABC", "11", "DEF" };

decimal total = 0m;
string message = "";

foreach (var value in values)
{
    decimal number;
    if (decimal.TryParse(value, out number))
    {
        total += number;
    } else
    {
        message += value;
    }
}

Console.WriteLine($"Message: {message}");
Console.WriteLine($"Total: {total}");
```


# sort and reverse array
```console
string[] pallets = { "B14", "A11", "B12", "A13" };

Console.WriteLine("Sorted...");
Array.Sort(pallets);
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Console.WriteLine("Reversed...");
Array.Reverse(pallets);
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
```
# clear and resize array
```console
string[] pallets = { "B14", "A11", "B12", "A13" };
Console.WriteLine("");

Array.Clear(pallets, 0, 2);
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Array.Resize(ref pallets, 6);
Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

pallets[4] = "C01";
pallets[5] = "C02";

foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
```

# Split() and Join() array
```console
string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
// string result = new string(valueArray);
string result = String.Join(",", valueArray);
Console.WriteLine(result);

string[] items = result.Split(',');
foreach (string item in items)
{
    Console.WriteLine(item);
}
```

# formatting strings
```console
string first = "Hello";
string second = "World";
string result = string.Format("{0} {1}!", first, second);
Console.WriteLine(result); 
result: Hello World!
```
# string interpolation
```console
decimal price = 123.45m;
int discount = 50;
Console.WriteLine($"Price: {price:C} (Save {discount:C})");
```

# padding and alignment
-  \t tab
```console
string paymentId = "769";
string payeeName = "Mr. Stephen Ortega";
string paymentAmount = "$5,000.00";

var formattedLine = paymentId.PadRight(6);
formattedLine += payeeName.PadRight(24);
formattedLine += paymentAmount.PadLeft(10);

Console.WriteLine(formattedLine);
```

```console
string paymentId = "769";
string payeeName = "Mr. Stephen Ortega";
string paymentAmount = "$5,000.00";

var formattedLine = paymentId.PadRight(6);
formattedLine += payeeName.PadRight(24);
formattedLine += paymentAmount.PadLeft(10);

Console.WriteLine("1234567890123456789012345678901234567890");
Console.WriteLine(formattedLine);
```

# indexof and Substring()
```console
string message = "Find what is (inside the parentheses)";

int openingPosition = message.IndexOf('(');
int closingPosition = message.IndexOf(')');

openingPosition += 1;

int length = closingPosition - openingPosition;
Console.WriteLine(message.Substring(openingPosition, length));
// output= inside the parentheses
```

# Remove() and Replace()
```console
string data = "12345John Smith          5000  3  ";
string updatedData = data.Remove(5, 20);
Console.WriteLine(updatedData);
//output:  123455000  3  
```

```console
string message = "This--is--ex-amp-le--da-ta";
message = message.Replace("--", " ");
message = message.Replace("-", "");
Console.WriteLine(message);
// output: This is example data
```

```console
```

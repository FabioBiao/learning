
# create project 
dotnet new console -o MyApp -f net6.0

#  run project
dotnet run 

# add package
dotnet add package <package name>
example, adding specific version: dotnet add package Humanizer --version 2.7.9

# remove package
dotnet remove package <name of dependency>

# check dotnet package list
dotnet list package

# To see what dependencies are outdated, run this command:
dotnet list package --outdated

# restore dependencies when importing a project
dotnet restore

# list sdks
dotnet --list-sdks

```console
<!-- Accepts any version 6.1 and later. -->
<PackageReference Include="ExamplePackage" Version="6.1" />

<!-- Accepts any 6.x.y version. -->
<PackageReference Include="ExamplePackage" Version="6.*" />
<PackageReference Include="ExamplePackage" Version="[6,7)" />

<!-- Accepts any later version, but not including 4.1.3. Could be
     used to guarantee a dependency with a specific bug fix. -->
<PackageReference Include="ExamplePackage" Version="(4.1.3,)" />

<!-- Accepts any version earlier than 5.x, which might be used to prevent pulling in a later
     version of a dependency that changed its interface. However, we don't recommend this form because determining the earliest version can be difficult. -->
<PackageReference Include="ExamplePackage" Version="(,5.0)" />

<!-- Accepts any 1.x or 2.x version, but not 0.x or 3.x and later. -->
<PackageReference Include="ExamplePackage" Version="[1,3)" />

<!-- Accepts 1.3.2 up to 1.4.x, but not 1.5 and later. -->
<PackageReference Include="ExamplePackage" Version="[1.3.2,1.5)" />
```

# Versioning:
- 1.1.1 changes to 1.2.0
The middle number represents the minor version. A change to this number means that features have been added. Your code should still work.

- 1.0.1 changes to 1.0.2
The third number is the patch version. A change to this number means that a change has been applied that fixes something in the code that should have worked.

# debugging
Console.WriteLine("This message is readable by the end user.");
Trace.WriteLine("This is a trace message when tracing the app.");
Debug.Write("Debug - ");
Debug.WriteLine("This is a debug message just for developers.");

Debug.WriteLineIf(count == 0, "The count is 0 and this may cause an exception.");

- with tracing
bool errorFlag = false;  
System.Diagnostics.Trace.WriteIf(errorFlag, "Error in AppendData procedure.");  
System.Diagnostics.Debug.WriteIf(errorFlag, "Transaction abandoned.");  
System.Diagnostics.Trace.Write("Invalid value for data request");

```console
To handle terminal input while debugging, you can use the integrated terminal (one of the Visual Studio Code windows) or an external terminal. For this tutorial, you use the integrated terminal.

Open .vscode/launch.json.

Change the console setting to integratedTerminal from:

JSON

Copy
"console": "internalConsole",
To:

JSON

Copy
"console": "integratedTerminal",
Save your changes.
```

# reading directories
- List all directories
```console
IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");

foreach (var dir in listOfDirectories) {
    Console.WriteLine(dir);
}
```
// Outputs:
// stores/201
// stores/202

- List files in a specific directory
```console
IEnumerable<string> files = Directory.EnumerateFiles("stores");
foreach (var file in files)
{
    Console.WriteLine(file);
}

// Outputs:
// stores/totals.txt
// stores/sales.json
```

List all content in a directory and all subdirectories
- Both the Directory.EnumerateDirectories and Directory.EnumerateFiles functions have an overload that accepts a parameter to specify that search pattern files and directories must match.
```console
// Find all *.txt files in the stores folder and its subfolders
IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles("stores", "*.txt", SearchOption.AllDirectories);

foreach (var file in allFilesInAllFolders)
{
    Console.WriteLine(file);
}

// Outputs:
// stores/totals.txt
// stores/201/inventory.txt
```

# Create directories
```console
Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));
```
If /stores/201 doesn't already exist, it will be created automatically. The CreateDirectory method won't fail. It will create any directories and subdirectories passed to it.

# Create File
You can create files by using the File.WriteAllText method. This method takes in a path to the file and the data you want to write to the file. If the file already exists, it will be overwritten.
```console
File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
```



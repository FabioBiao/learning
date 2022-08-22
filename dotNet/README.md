

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

```console
Console.WriteLine("This message is readable by the end user.");
Trace.WriteLine("This is a trace message when tracing the app.");
Debug.Write("Debug - ");
Debug.WriteLine("This is a debug message just for developers.");

Debug.WriteLineIf(count == 0, "The count is 0 and this may cause an exception.");


Bellow writes when attached to a debugger in the debug console output.
System.Diagnostics.Debug.WriteLine
System.Diagnostics.Debug.WriteIf(errorFlag, "Transaction abandoned.");  

bool errorFlag = false;  
System.Diagnostics.Trace.WriteIf(errorFlag, "Error in AppendData procedure.");  
System.Diagnostics.Trace.Write("Invalid value for data request");
// If n2 is 5 continue, else break.
Debug.Assert(n2 == 5, "The return value is not 5 and it should be.");

```

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

# run project
dotnet run
or 
on visual studio green start arrow


# create new page, "Blazor component"
To inject services into that component, we need to create the services.
Then import them to program.cs and imports.razor


# entity framework configuration
- add dependency of add a class

add nuget package -> install microsoft.entityFrameworkCore
and install microsoft.entityFrameworkCore.Design if you want to create migrations as well.
and microfot.entityFrameworkCore.SqlServer

-Opening package manager console   "View -> other windows -> package manager console"

Check entity frameworks installed   ( install if you dont have it https://stackoverflow.com/questions/57066856/command-dotnet-ef-not-found: dotnet tool install --global dotnet-ef)
- dotnet-ef


So, we create a folder that defines the data "Data" folder, we add the "global using Microsoft.EntityFrameworkCore;" to the program.cs

- Migrations
move inside the server folder, and run migration command
```` console
 cd .\BlazorFullStackCrud\server
 dotnet ef migrations Initial  // creates the migrations folder 
 dotnet ef database update  // updates the database
 ````
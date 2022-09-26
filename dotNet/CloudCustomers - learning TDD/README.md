# starting your project
- dotnet new sln -o CloudCustomers

# create API project
- dotnet new webapi -o CloudCustomers.API

# Create tests Project with xunit
- dotnet new xunit -o CloudCustomers.UnitTests

# add projects to the solution
- dotnet sln add **/*.csproj
for windows
- dotnet sln add (ls -r **/*.csproj)

# packages to test
- Moq by Daniel Cazzulino    ( to mock stuff)
- fluentAssertions by Dennis Doomen (provices a better syntax to create assertions)

# how to add project dependencies
- right click on the project -> Add -> project reference -> select project you want to create dependency

# to run tests
- click "View" ->"Test Explorer", this should detect the tests we created

# Dependency Inversion principle (from SOLID)
High-level modules should not depend on low-level modules. Both should depend on abstractions.
Abstractions should not depend on details. Details(i.e implementations) should depend on abstractions.


- based on the TDD video
https://www.youtube.com/watch?v=ULJ3UEezisw



# list sorted
-no duplicates
- elements are always sorted (as opposed to Hashsets)
SortedSet<int> mySet = new SortedSet<int>();
mySet.Add(3);
mySet.Add(12);
mySet.Add(1);
mySet.Add(3);
// mySet: [1,3,12]



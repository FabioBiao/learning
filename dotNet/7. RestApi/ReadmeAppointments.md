- Two projects, one with the definition of the APi and one with the logic of the application

# commands

- dotnet new sln -o BuberBreakfast
- dotnet new classlib -o BuberBreakfast.Contracts
- dotnet new webapi -o BuberBreakfast

## add projects to the solution
- code .   | opens visual studio on current directory
- dotnet sln add .\BuberBreakfast.Contrats .\BuberBreakfast\
- or add all projects recursively "dotnet sln add (ls -r **/*.csproj)
- dotnet build
- dotnet run
- dotnet watch run --project .\Projecthere.Api\

- dotnet add .\BuberBreakfast\ package ErrorOr    

## add references between the two projects
- dotnet add .\BuberBreakfast\ reference .\BuberBreakfast.Contracts\

# installed Markdown Preview Enhanced
- Settings -> Packages -> markdown-preview-enhanced -> Settings.
- select your atom theme

# installed Rest Client by  Huachao Mao
- this allows to run requests like on postamn (request folder constains the requests)
- if we want to make multiple definitions of requests inside the same file write ### between the requests
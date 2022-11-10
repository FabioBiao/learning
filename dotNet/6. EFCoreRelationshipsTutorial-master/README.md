
# swagger
https://localhost:7192/swagger/index.html


- https://www.youtube.com/watch?v=FHx6AGVF_IE


- Migrations
move inside the server folder, and run migration command
```` console
 cd .\BlazorFullStackCrud\server
 dotnet ef migrations Initial  // creates the migrations folder 
 dotnet ef migrations add Initial
 dotnet ef database update  // updates the database
 ````
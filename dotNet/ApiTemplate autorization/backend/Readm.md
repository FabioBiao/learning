# cookie and jwt
- https://weblog.west-wind.com/posts/2022/Mar/29/Combining-Bearer-Token-and-Cookie-Auth-in-ASPNET

# authentication schemes and add policys
- https://code-maze.com/dotnet-multiple-authentication-schemes/
# auth cookies
- https://code-maze.com/cookie-authentication-aspnetcore-angular/

# custom authorization
https://stackoverflow.com/questions/31687955/authorizing-a-user-depending-on-the-action-name/31688792#31688792


# lifetimes of services
-  AddSingleton - the first time the server requests the IBreakfastService then create a new object BreakfastService, but from now on throughout the lifetime of the application every time someone requests the interface IBreakfastService, always use the same object "BreakfastService" we just created
- AddScoped - the first time the server requests the IBreakfastService then create a new object BreakfastService,but from now until we finish this request, every time we create an object and it requests this interface then return the same object we just created 
- AddTransient - every time someone requests this interface, create a new BreakfastService object


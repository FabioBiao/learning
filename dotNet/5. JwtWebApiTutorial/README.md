
# swagger
https://localhost:7192/swagger/index.html

# creating project
- create new asp.net core web api

# packages installed
- System.IdentityModel.Tokens.Jwt
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore.Filters;

# authorizations 
Can be added at the controller level
````
    [ApiController]
    [Route("[controller]")]
    [Authorize]
````
if the controller is secured as above, but we want to allow one method
````
[HttpGet(Name = "GetWeatherForecast"), AllowAnonymous]
````

or at the endpoint level.. as in our example.

````
[HttpGet(Name = "GetWeatherForecast"), Authorize]
````

# testing
- after we add our custom code to test on swagger, click on swagger authorize and write: "bearer tokenHERE" we should be able to call authorized apis after this
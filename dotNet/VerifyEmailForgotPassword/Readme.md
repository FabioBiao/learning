# packages
- microsoft.entityFrameworkCore
- microsoft.entityFrameworkCore.design
- microsoft.entityFrameworkCore.SqlServer

## emails - https://www.youtube.com/watch?v=PvO_1T0FS_A
# dummy email sender https://ethereal.email/
- mailkit by Jeffrey  

# install et globally
- dotnet tool install --global dotnet-ef
- dotnet tool update --global dotnet-ef

# run migrations
- dotnet ef migrations add Initial
- dotnet ef database update

# jwt packages
- Microsoft.AspNetCore.Authentication.JwtBearer by microsoft (3.1.20)
- Microsoft.IdentityModel.Tokens by microsoft (6.14.0)
- System.IdentityModel.Tokens.Jwt by microsoft (6.14.0)

## random key generator
- https://www.random.org/strings/

# docker 
- Build the docker
`docker build -t api_sample -f dockerfile .`
- list docker images
`docker images`
- Run docker
`docker run -it -d -p 8000:80 --name api_container api_sample`
- list running containers
`docker ps`

# run project locally
- dotnet watch run --project .\VerifyEmailForgotPasswordTutorial\
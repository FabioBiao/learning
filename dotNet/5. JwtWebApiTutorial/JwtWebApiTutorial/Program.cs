global using JwtWebApiTutorial.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

/////////////////////////////////
// injecting new services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpContextAccessor(); // addind default implementation for HttpContextAccessor used in UserService
// custom code for authentication
// first builder adds tokens to swagger, to allow our tests
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
//builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
//    policy =>
//    {
//        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
//    }));
// end custom code for authentication
////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
/////////////////////////////////
// custom code for authentication, this needs to be above the use authorizarion
app.UseAuthentication();
// end custom code for authentication
////////////////////////////////////
app.UseAuthorization();

app.MapControllers();

app.Run();
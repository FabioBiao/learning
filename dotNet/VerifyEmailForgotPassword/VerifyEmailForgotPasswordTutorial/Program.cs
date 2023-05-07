global using Microsoft.EntityFrameworkCore;
global using VerifyEmailForgotPasswordTutorial.Models;
global using VerifyEmailForgotPasswordTutorial.Data;
global using SimpleEmailApp.Services.EmailService;
global using SimpleEmailApp.Models;

/* jwt */
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;  // for SecurityRequirementsOperationFilter
using System.Text; // for the encoding to work

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<DataContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IEmailService, EmailService>();


/* JWT code*/

// line to add autorization to swagger
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
// authenticatin of jwt
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme
    )
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)
                ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
    );

/* JWT code end*/

/* Cors 
 builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
   policy =>
   {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));
 */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

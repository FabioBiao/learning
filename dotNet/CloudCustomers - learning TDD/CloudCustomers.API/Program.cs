using CloudCustomers.API.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// added here 
// factory
ConfigureServices(builder.Services);

void ConfigureServices(IServiceCollection services)
{
    // add singleton,that lives through the live time of the application
    services.Configure<UsersApiOptions>(builder.Configuration.GetSection("UsersApiOptions"));

    services.AddTransient<IUsersService, IUsersService>();
    services.AddHttpClient<IUsersService, IUsersService>();
}
// added above


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

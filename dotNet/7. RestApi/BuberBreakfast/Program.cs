using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();

    // AddSingleton - the first time the server requests the IBreakfastService then create a new object BreakfastService, 
    // but from now on throughout the lifetime of the application every time someone requests the interface IBreakfastService, 
    // always use the same object "BreakfastService" we just created

    // AddScoped - the first time the server requests the IBreakfastService then create a new object BreakfastService,
    // but from now until we finish this request, every time we create an object and it requests this interface then return the 
    // same object we just created 

    // AddTransient - every time someone requests this interface, create a new BreakfastService object
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error"); // added middleware to handle errors
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
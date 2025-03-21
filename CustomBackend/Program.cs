var builder = WebApplication.CreateBuilder(args);

// Step 1: Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:1337")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add controller services
builder.Services.AddControllers();

var app = builder.Build();

// Step 2: Use CORS middleware
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
using SimpleTaskManagerApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleTaskManagerApi V1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
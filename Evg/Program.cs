// Ваш код настройки приложения

using Evg.Components.Models;
using Evg.Components;

var builder = WebApplication.CreateBuilder(args);

// Зарегистрируйте AppSettings в контейнере зависимостей
builder.Services.AddSettings1(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
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

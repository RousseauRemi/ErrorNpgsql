using ErrorNpgsql.Configuration;
using ErrorNpgsql.Datas;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDataLayerRunTime(configuration);
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/group", ([FromServices] CustomDbContext context) => context.Groups.ToList())
    .WithName("GetGroup")
    .WithOpenApi();

app.Run();

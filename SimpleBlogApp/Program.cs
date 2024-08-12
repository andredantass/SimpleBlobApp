using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SimpleBlogApp.API.Extension;
using SimpleBlogApp.Infra.Data.DBContext;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();
builder.Services.AddHttpContextAccessor();
builder.Services.AddServices();
builder.Services.AddRepository();

builder.Services.AddDbContext<SimpleBlogDbContext>(options =>
{
    var cnn = builder.Configuration.GetConnectionString("SimpleBlogDB");

    options.UseSqlServer(cnn);
});

var app = builder.Build();


app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseWebSockets();
app.AddAuthenticationMiddleware();
app.UseWebSocketsServer();

await app.RunAsync();

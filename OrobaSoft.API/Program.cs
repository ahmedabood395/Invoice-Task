using MediatR;
using Microsoft.EntityFrameworkCore;
using OrobaSoft.Repository.Context;
using System.Reflection;
using OrobaSoft.Repository.DI;
using OrobaSoft.Service.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("OrobaSoft.Service"));
builder.Services.RegisterRepository();
builder.Services.RegisterService();

builder.Services.AddDbContext<InvoiceContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            options.EnableSensitiveDataLogging(true);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:7048")
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowCors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

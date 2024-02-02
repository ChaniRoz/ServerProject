using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Interface;
using DAL.Data;

string myCors = "_myCors";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(op =>
{

    op.AddPolicy(myCors,
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
builder.Services.AddDbContext<Context>(op => op.UseSqlServer("Data Source=CHANI\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=SSPI;Trusted_Connection=True;"));
builder.Services.AddScoped<IToDo,ToDoData>();
builder.Services.AddScoped<IUsers, UsersData>();
builder.Services.AddScoped<IPost, PostData>();
builder.Services.AddScoped<IPhoto, PhotoData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

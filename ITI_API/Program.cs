using ITI_API.Interfaces;
using ITI_API.Models;
using ITI_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string cors = "";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenerricReposatory<>));
builder.Services.AddDbContext<ItiContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(cors, policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod()
        //.AllowAnyOrigin();
        .WithOrigins("https://vaulted.com");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.UseCors(cors);
app.Run();
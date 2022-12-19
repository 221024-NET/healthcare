using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connValue = builder.Configuration["ConnectionStrings:Azure"];
//builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(connValue));
builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(connValue));

builder.Services.AddScoped<IContext>(provider => provider.GetService<Context>());

var healthcareAPI = "_healthcareAPI";
builder.Services.AddCors(options => {
    options.AddPolicy(name: healthcareAPI,
    policy => {
        policy.WithOrigins("http://localhost:4200") //4200 is the default when running angular
    .AllowAnyHeader()
    .AllowAnyMethod();
    });
});

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



app.UseCors(healthcareAPI);



app.Run();

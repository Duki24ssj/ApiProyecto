using ApiProyecto.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(//c =>
//{
  //  c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyectoInventarioAPI", Version = "v1" });
//}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(//c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoInventarioAPI v1")
                     );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

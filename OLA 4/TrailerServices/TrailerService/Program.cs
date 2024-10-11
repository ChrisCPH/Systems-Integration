using Microsoft.EntityFrameworkCore;
using TrailerService.Data;
using TrailerService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TrailerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrailerDatabase")));

builder.Services.AddScoped<TrailerService>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

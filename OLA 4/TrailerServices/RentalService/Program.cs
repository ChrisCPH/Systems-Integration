using Microsoft.EntityFrameworkCore;
using RentalService.Data;
using RentalService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrailerDatabase")));

builder.Services.AddHttpClient<RentalService>();
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

using PatientConnect.Hubs;
using PatientConnect.Data;
using PatientConnect.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSignalR();
builder.Services.AddSingleton<IDictionary<string, Connection>>(option => new Dictionary<string, Connection>());

builder.Services.AddDbContext<PatientConnectContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString(nameof(PatientConnectContext)), new MySqlServerVersion(new Version(10, 11, 6)));
});

// Store session into Web-Server memory.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Make the session cookie essential.
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed data.
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch(Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");

//app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapHub<ChatHub>("/chatHub");

app.MapDefaultControllerRoute();

app.Run();
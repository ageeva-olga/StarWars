using Microsoft.EntityFrameworkCore;
using DAL;
using StarWars;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();

var provider = builder.Services.BuildServiceProvider();
var factory = provider.GetService<ILoggerFactory>();
factory.AddNLog();
factory.ConfigureNLog("nlog.config");

var logger = provider.GetService<ILogger<Program>>();
builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(_ => logger);

builder.Services.AddDbContext<SWDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("StarWarsDatabase")));

builder.Services.AddControllers();

builder.Services.AddBllServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarWars", Version = "v1" });
}); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarWars v1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();

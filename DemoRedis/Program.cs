using DemoRedis.Installers;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallerServicesInAssembly(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var options = ConfigurationOptions.Parse("red-ctl41alumphs73d72blg:0Qj1q1ydfWQZegpArbAZL5EvSjVnIJAj@oregon-redis.render.com:6379");
options.Ssl = true; // B?t TLS
options.AbortOnConnectFail = false; // Không d?ng khi l?i k?t n?i
options.SyncTimeout = 10000; // T?ng th?i gian ch? k?t n?i (10 giây)

var multiplexer = ConnectionMultiplexer.Connect(options);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

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

app.Run();

using ConfigCentric.Api.AppService;
using ConfigCentric.Api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ConfigValueAppService).Assembly);
builder.Services.AddScoped<ProjectAppService>();
builder.Services.AddScoped<EnvironmentAppService>();
builder.Services.AddScoped<ConfigValueAppService>();
builder.Services.AddDbContext<ConfigCentricDbContext>(b =>
            {
                string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings");
                b.UseNpgsql(connectionString);
            });

var  AllOrigins = "_AllOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                      });
});            


var app = builder.Build();

app.UseCors(AllOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

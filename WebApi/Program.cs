using Crm.Config;
using WebApi.Common.JwtConfig;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("myPolicy",
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

BootstrapperConfig.DependencyInjectionConfig
    (builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddTransient<CustomJwtValidation>();

builder.Services.AddStackExchangeRedisCache( option =>
{
    option.Configuration = "localhost:6379";
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("myPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
app.UseCors();

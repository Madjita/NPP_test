using test_npp_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using test_npp_api.Services.Repository;
using test_npp_api.Services.User;
using test_npp_api.Services.Tool;
using test_npp_api.Services.Tool_User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
                        .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IToolService, ToolService>();
builder.Services.AddTransient<IToolUserService, ToolUserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// подключаем CORS
app.UseCors(x =>
            x.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .WithExposedHeaders("Content-Disposition")
);

app.UseAuthorization();

app.MapControllers();

app.Run();


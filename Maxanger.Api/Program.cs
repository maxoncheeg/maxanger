using System.Reflection;
using System.Text.Json.Serialization;
using Maxanger.Api.Configurations;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Controllers.v1.Hubs;
using Maxanger.Api.Middlewares;
using Maxanger.CompositionRoot;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddVersioning();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddHttpContextAccessor();
builder.Services.AddDomainServices().AddApiServices().AddMediatRHandlers();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            // Для отладки разрешите любой домен, потом замените на конкретный
            .SetIsOriginAllowed(_ => true) 
            .AllowCredentials(); // Важно для куков/авторизации
    });
});
;

builder.Services
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo() { Title = "CodeVersioning", Version = "1" });
        options.SwaggerDoc("v2", new OpenApiInfo() { Title = "CodeVersioning", Version = "2" });
        options.AddSignalRSwaggerGen();
    });

builder.Services.AddSignalR();

var configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

await builder.Services.AddPostgresDatabase(connectionString).MigratePostgresDatabaseAsync();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors("AllowAll"); 

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", async context => context.Response.Redirect("/swagger"));

app.MapHub<MaxangerHub>(MaxangerRoutes.Chat.Hub);

// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeVersioning v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "CodeVersioning v2");
        //options.SwaggerEndpoint("/swagger/v3/swagger.json", "CodeVersioning v3");
    });
// }

app.Run();
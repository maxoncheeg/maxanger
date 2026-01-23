using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Controllers.v1.Hubs;
using Maxanger.Api.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
    {
        //Версия API по умолчанию
        options.DefaultApiVersion = new ApiVersion(1);
        //Добавляем специальные HTTP-заголовки, в которых перечислены актуальные и устаревшие версии API
        options.ReportApiVersions = true;
        //Используем версию API по умолчанию, если клиент явно не указал нужную ему
        options.AssumeDefaultVersionWhenUnspecified = true;
        //Определяем, что будем ожидать нужную версию API в самой строке запроса или в URL-сегменте
        options.ApiVersionReader =
            new UrlSegmentApiVersionReader(); //site.com/v2/getdata
    })
    //Подключаем поддержку MVC для версионирования API
    .AddMvc()
    //Данный метод исправляет конечные маршруты и подставляет нужную версию API через параметр в маршруте.
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
;

builder.Services
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo() { Title = "CodeVersioning", Version = "v1" });
        options.SwaggerDoc("v2", new OpenApiInfo() { Title = "CodeVersioning", Version = "v2" });
        //options.SwaggerDoc("v3", new OpenApiInfo() { Title = "CodeVersioning", Version = "v3" });
    });
builder.Services.AddSignalR();
var app = builder.Build();


//app.UseMiddleware<TokenMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();


//app.UseOpenTelemetryPrometheusScrapingEndpoint();

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

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();
app.MapGet("/", async context => context.Response.Redirect("/swagger"));
app.MapHub<ChatChatHub>(MaxangerRoutes.Chat.Hub);
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
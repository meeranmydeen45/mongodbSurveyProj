using Survey.Api.Cloud.Core.Service;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Survey.Api.Cloud.Core.DataBase.DBContext;
using Survey.Api.Cloud.Core.Database.Mongo;
using Survey.Api.Cloud.Core.Services;
using Survey.Api.Cloud.Core.BusinessLogic;
using Survey.Api.Cloud.Core.BusinessRepository;
using Survey.Api.Cloud.Core.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDatabase"));

string connectionString = builder.Configuration.GetConnectionString("DbConnection") ?? "na";

if(connectionString != "na")
{
    builder.Services.AddDbContext<SurveyDBContext>(option => option.UseNpgsql(connectionString));
}

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Survey API", Version = "v1" });
});

builder.Services.AddTransient<ISurveyBl, SurveyBl>();
builder.Services.AddTransient<ISurveyBr, SurveyBr>();
builder.Services.AddSingleton<MongoService>();

builder.Services.AddControllers();
builder.Services.AddCors();


var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Survey API v1"));
app.UseHttpsRedirection();
app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.MapControllers();

app.MigrateDatabase();

app.Run();

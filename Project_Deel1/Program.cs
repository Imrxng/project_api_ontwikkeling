using Ghaddoura_Imran_Project.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

using Ghaddoura_Imran_Project.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var database = builder.Configuration.GetValue<bool>("database");

if (database)
{
    builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.
        GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IUniversityService, UniversityServiceDb>();
    builder.Services.AddScoped<IResultsService, ResultsServiceDb>();
    builder.Services.AddScoped<IStudentsService, StudentsServiceDb>();

} else
{
    builder.Services.AddSingleton<InMemoryContext>();
    builder.Services.AddScoped<IUniversityService, UniversityService>();
    builder.Services.AddScoped<IResultsService, ResultsService>();
    builder.Services.AddScoped<IStudentsService, StudentsService>();
}

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services
 .AddControllers()
 .AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.ReferenceHandler =
    ReferenceHandler.IgnoreCycles;
 });

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

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ReportAPI.Data.Context;
using PhoneBookAssessment.ReportAPI.Models;
using PhoneBookAssessment.ReportAPI.Repositories;
using PhoneBookAssessment.ReportAPI.Repositories.Common;
using PhoneBookAssessment.ReportAPI.Services;
using PhoneBookAssessment.ReportAPI.Services.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ReportDbContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("ReportAPIDbConnection"))
); 
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IMessageService,MessageService>();
builder.Services.AddScoped<IReportService,ReportService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseQueueService();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

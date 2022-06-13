using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ContactAPI.Data.Context;
using PhoneBookAssessment.ContactAPI.Repositories;
using PhoneBookAssessment.ContactAPI.Repositories.Common;
using PhoneBookAssessment.ContactAPI.Services;
using PhoneBookAssessment.ContactAPI.Services.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ContactDbContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("ContactAPIDbConnection"))
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


using API.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("licensekeyDBCon")));



builder.Services.AddDbContext<HsenidUserContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("licensekeyDBCon")));


builder.Services.AddDbContext<PartnerContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("licensekeyDBCon")));

builder.Services.AddDbContext<ClientContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("licensekeyDBCon")));

builder.Services.AddDbContext<LicenseKeyContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("licensekeyDBCon")));

builder.Services.AddDbContext<ActivateContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("licensekeyDBCon")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

//JSON Serializer
builder.Services.AddControllers().AddNewtonsoftJson(options=>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());



var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});
app.UseAuthorization();

app.MapControllers();

app.Run();


using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Mappings;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.EndClientSerives;
using license_management_system_Sever_side.Services.ModuleSerives;
using license_management_system_Sever_side.Services.PartnerSerives;
using license_management_system_Sever_side.Services.RequestKeySerives;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddControllers();*/

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddCors();

builder.Services.AddScoped<IEndClientService, EndClientService>();
builder.Services.AddScoped<IPartnerSerives, PartnerSerives>();
builder.Services.AddScoped<IModuleSerives, ModuleSerives>();
builder.Services.AddScoped<IRequestKeySerives, RequestKeySerives>();

var app = builder.Build();




    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Mappings;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.INDashboardServices;
using license_management_system_Sever_side.Services.ActivateKeySerives;
using license_management_system_Sever_side.Services.EmailServices.ContectMail;
using license_management_system_Sever_side.Services.EmailServices.KeyEmail;
using license_management_system_Sever_side.Services.EndClientSerives;
using license_management_system_Sever_side.Services.LicenseKeyServices;
using license_management_system_Sever_side.Services.LogingValidateInfoSerives;
using license_management_system_Sever_side.Services.ModuleSerives;
using license_management_system_Sever_side.Services.NotificationSerives;
using license_management_system_Sever_side.Services.PartnerSerives;
using license_management_system_Sever_side.Services.RequestKeySerives;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureDbCon"));
});// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddCors();


builder.Services.AddScoped<IInDashboardService, InDashboardService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IKeyEmailService, KeyEmailService>();
builder.Services.AddScoped<IContectEmalService, ContectEmalService>();
builder.Services.AddScoped<IEndClientService, EndClientService>();
builder.Services.AddScoped<IPartnerSerives, PartnerSerives>();
builder.Services.AddScoped<IModuleSerives, ModuleSerives>();
builder.Services.AddScoped<IRequestKeySerives, RequestKeySerives>();
builder.Services.AddScoped<ILicenseKeyServices, LicenseKeyServices>();
builder.Services.AddScoped<INotificationsSerives, NotificationsSerives>();
builder.Services.AddScoped<IActivateKeySerives, ActivateKeySerives>();
builder.Services.AddScoped<ILogingValidateInfoSerives, LogingValidateInfoSerives>();



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
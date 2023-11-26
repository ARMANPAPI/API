using CityInfo.API;
using CityInfo.API.DbContexts;
using CityInfo.API.Repositories;
using CityInfo.API.Service;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

#region For Logging(Loger)
//
//Pakages :
//  .sinks.console\4.1.0\
//serilog.aspnetcore\6.1.0\
//serilog.sinks.file\5.0.0\

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/ctyinfo.text", rollingInterval: RollingInterval.Day)
    .CreateLogger();
///

#endregion

var builder = WebApplication.CreateBuilder(args);

//For Use Serilog Project Changer That ILogger
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers(option =>
{
    option.ReturnHttpNotAcceptable = true;
    // تعینن فرمت خروجی و ورودی
    //option.OutputFormatters.Add();
    //option.InputFormatters.Add();
    //
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region AllServices


#region AutoMpper

//Packages Fr AuotMaper :

//automapper\12.0.1\
//automapper.extensions.microsoft.dependencyinjection\12.0.1\

// AppDomain.CurrentDomain.GetAssemblies() => اشاره به همین پروژه
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region For File
//AddSingleton => یدونه بزار همه بتونن ازش استفاده کنن
//packages For File Patch:
//microsoft.aspnetcore.mvc.newtonsoftjson\6.0.21\
//microsoft.aspnetcore.jsonpatch\7.0.10\
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
#endregion

#region For Email Sending
builder.Services.AddScoped<IMailService, localMailService>();
#endregion


#region ConectionString For SQlLite

builder.Services.AddDbContext<CityInfoDbContext>(option =>
{
    //For SQLite
    // option.UseSqlite(builder.Configuration.GetConnectionString("CityInfo.API"));
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionSQLServer"));
});

#endregion

#region Repository

builder.Services.AddScoped<ICityInfoRepositoriy, CityInfoRepositoriy>();

#endregion

#region For Security API
//microsoft.aspnetcore.authentication.jwtbearer\6.0.21\

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(option =>
//    {
//        option.TokenValidationParameters = new()
//        {
//            ValidateIssuer = true,
//            ValidateIssuerSigningKey = true,
//            ValidateAudience = true,
//            ValidIssuer = builder.Configuration["Authentication:Issuer"],
//            ValidAudience = builder.Configuration["Authentication:Audience"],

//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))

//        };
//    });
#endregion 

#endregion

#region Lerning AddScoped - AddTransient - AddSingleton

//builder.Services.AddScoped<localMailService>();
//یک بار ساخته میشود و ما میتوانیم مثلا 20 بار ایمیل بفرستیم

//builder.Services.AddTransient<localMailService>();
// به اعضای هر باریکه ما کلاسی که صدا زدیم درش و فرخوانی کنیم برای ما نمونه گیری میشود و بعد پاک میشه

//builder.Services.AddSingleton<localMailService>();
//برای تمام کاربران یک بار از کلاسم میسازه و تمام کاربران از ان استفاده میکنن
#endregion



#region PipeLine
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //If IsDevelpemnt For Me Loding Programing
    //If IsStaging For Me Loding Programing For Debuging
    //If IsProduction For Finail Project
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Use Rout
app.UseRouting();
//For Security API
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

#endregion


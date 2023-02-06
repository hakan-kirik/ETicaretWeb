using ETicaretApi.API.Configurations.ColumnWriter;
using ETicaretApi.Application;
using ETicaretApi.Application.Validators.Products;
using ETicaretApi.Infrastructure;
using ETicaretApi.Infrastructure.Filters;
using ETicaretApi.Infrastructure.Services.Storage.Azure;
using ETicaretApi.Infrastructure.Services.Storage.Local;
using ETicaretApi.Persistance;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddPersistanceServices();
builder.Services.AddInfastructureServices();
builder.Services.AddApplicationServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.PostgreSQL(connectionString:builder.Configuration.GetConnectionString("PostgreSQL"),tableName:"logs",
    needAutoCreateTable:true,
    columnOptions:new Dictionary<string, ColumnWriterBase>
    {
        {"message",new RenderedMessageColumnWriter() },
        {"message_template",new MessageTemplateColumnWriter() },
        {"level",new LevelColumnWriter(true,NpgsqlTypes.NpgsqlDbType.Varchar) },
        {"time_stamp",new TimestampColumnWriter() },
        {"exception",new ExceptionColumnWriter() },
        {"log_event",new LogEventSerializedColumnWriter(NpgsqlTypes.NpgsqlDbType.Json) },
        {"user_name",new UsernameColumnWriter() }
    }
    )
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>()).AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter=true);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", option =>
    {
        option.TokenValidationParameters = new()
        {
            ValidateAudience = true,//olustulan tokenin kimlerin kullanacagini belirten deger
            ValidateIssuer =true,//olusturulan alananin kim tarafindan dagildigini belirtir
            ValidateLifetime=true,//olusuturulan tokenin  suresini kontrol edecek deger
            ValidateIssuerSigningKey= true,//security key dogrulanmasi
            
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer= builder.Configuration["Token:Issuer"],
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
			//LifetimeValidator =(notBefore, expires, securityToken, validationParameters) => { return expires > DateTime.UtcNow; },
			
			ClockSkew = TimeSpan.Zero,

			NameClaimType =ClaimTypes.Name
		};
    });




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User.Identity.IsAuthenticated != null || true ? context.User.Identity.Name : null;
 
    LogContext.PushProperty("user_name", username);
    await next();
});

app.MapControllers();

app.Run();

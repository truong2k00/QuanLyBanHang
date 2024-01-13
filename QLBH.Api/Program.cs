using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QLBH.Api.Extensions;
using QLBH.Api.MiddleWare;
using QLBH.Business;
using QLBH.Commons;
using QLBH.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddSwaggerGen();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(option =>
//{
//    option.SwaggerDoc("v1", new OpenApiInfo { Title = "NS.Core API", Version = "v1" });
//    option.CustomSchemaIds(type => type.ToString());
//    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter a valid token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });
//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDefault")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                          //policy.WithOrigins("https://localhost:3000");
                      });
});

builder.Services.AddControllers();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection(Common_Constants.AppSettingKeys.AUTH_SECRET).Value))
    };
});

builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");

builder.Services.AddTransient<ExceptionHandlerMiddleWare>();
builder.Services.AddTransient<JWTMiddleware>();

builder.Services.AddHttpContextAccessor();

builder.Services.DependencyServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UserDataSeeding();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UserDataSeeding(true);
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseMiddleware<JWTMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
#region
//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseCors(MyAllowSpecificOrigins);

//app.UseCors();

//app.UseHttpsRedirection();

//app.UseMiddleware<ExceptionHandlerMiddleWare>();
//app.UseMiddleware<JWTMiddleware>();

////app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
#endregion
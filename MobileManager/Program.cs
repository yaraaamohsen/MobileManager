using System.Text;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Presentation;
using Presentation.CustomMiddleware;

namespace MobileManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddSingleton<ITokenService, TokenService>();
            builder.Services.AddScoped<IDataService, DataService>();

            // Configure JWT Authentication
            builder.Services.AddAuthentication(Config =>
            {
                Config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["jwtOptions:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["jwtOptions:Audience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtOptions:SecretKey"]))

                };
            });

            builder.Services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errorMessage = "Error Message Description";
                    var response = new BaseResponse<object>(errorMessage);
                    return new BadRequestObjectResult(response);
                };
            });

            var app = builder.Build();

            app.UseMiddleware<CustomExceptionMiddlewareHandler>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

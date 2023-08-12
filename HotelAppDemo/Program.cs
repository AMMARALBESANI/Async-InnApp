using AmemitiesAppDemo.Model.services;
using HotelAppDemo.Controller;
using HotelAppDemo.Data;
using HotelAppDemo.Model;
using HotelAppDemo.Model.Interfaces;
using HotelAppDemo.Model.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelAppDemo
{
    public class Program
    {
        //1-create class to be gate between our app and database it must inherate DbContext form entity backage

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //9-add this ststment 
           
            builder.Services.AddControllers();

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            //4- we add connstring to establish the connection between our app and database 
            string connstring = builder.Configuration.GetConnectionString("DefaultConnection");
            // 5- we tell our code to use HotelDbContext this class as gate between us
            builder.Services
                .AddDbContext<HotelDbContext>
                // to tell the code we ues sqlserver
                (options => options.UseSqlServer(connstring));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            })
            .AddEntityFrameworkStores<HotelDbContext>();

            builder.Services.AddTransient<IUser, IdentityUserService>();

            builder.Services.AddTransient<IHotel, HotelServices>();

            builder.Services.AddTransient<IRoom, RoomServices>();

            builder.Services.AddTransient<IAmenities,AmenitiesServices>();

            builder.Services.AddTransient<IHotelRoom, HotelRoomServices>();

            builder.Services.AddScoped<jwtTokenServices>();


            builder.Services.AddAuthentication(options =>
            {
             options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = jwtTokenServices.GetValidationParameters(builder.Configuration);
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("create", policy => policy.RequireClaim("persmissions", "create"));
                options.AddPolicy("update", policy => policy.RequireClaim("persmissions", "update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("persmissions", "delete"));
                options.AddPolicy("read", policy => policy.RequireClaim("persmissions", "read"));
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.
                    OpenApiInfo()
                {
                    Title = "HotelAppDemo",
                    Version="v1"
        
                });
            });

            var app = builder.Build();

             app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //9-a- add this statment 
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json","Hotel ApI");
                options.RoutePrefix = "docs";
            });
            
            app.MapControllers();

            
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
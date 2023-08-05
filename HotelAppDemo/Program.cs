using AmemitiesAppDemo.Model.services;
using HotelAppDemo.Controller;
using HotelAppDemo.Data;
using HotelAppDemo.Model;
using HotelAppDemo.Model.Interfaces;
using HotelAppDemo.Model.services;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddTransient<IHotel, HotelServices>();

            builder.Services.AddTransient<IRoom, RoomServices>();

            builder.Services.AddTransient<IAmenities,AmenitiesServices>();

            builder.Services.AddTransient<IHotelRoom, HotelRoomServices>();

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
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

            var app = builder.Build();
            //9-a- add this statment 

            
            app.MapControllers();

            app.UseMvc();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
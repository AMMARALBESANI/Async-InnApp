using HotelAppDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelAppDemo
{
    public class Program
    {
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
            var app = builder.Build();
            //9-a- add this statment 
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
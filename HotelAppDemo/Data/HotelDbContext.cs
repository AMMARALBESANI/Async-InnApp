using HotelAppDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Generic;

namespace HotelAppDemo.Data
{
    public class HotelDbContext : DbContext
    {

        // 2-create a constractor and give it a parameter DbContextOptions will take different configrations for database 
        public HotelDbContext(DbContextOptions options) : base(options)
        {
           

        
        }

        //7-We override method from dbcontext called OnModelCreating 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                   new Hotel() {Id=1 , Name= "Async Inn" , City="Paris" , Country ="France" , State =" Paris" , StreetAdress = "Paris-France" , Phone ="00560078"},
                   new Hotel() {Id=2 , Name= "Async Inn" , City="Amman" , Country ="Jordan" , State =" Amman" , StreetAdress = "DownTawn" , Phone ="00962788996677"},
                   new Hotel() {Id=3 , Name= "Async Inn" , City="Qairo" , Country ="Egypt" , State ="Qairo" , StreetAdress = "SalahSalem" , Phone ="0156005098"}
                );

            modelBuilder.Entity<Room>().HasData(
              new Room() { Id = 1, Name = "RainTrain", layout = 2 },
              new Room() { Id = 2, Name = "GreenForest", layout = 1 },
              new Room() { Id = 3, Name = "RainTrain", layout = 3 }
            );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities() { Id=1, Name="Ac"},
                new Amenities() { Id=2, Name="CoffeMaker"},
                new Amenities() { Id=3, Name="Sawna"}
                );

            //8-add new folder (controler ) and add contorler for all classes in model from api then action entity fram work and we must install laibrary call codegeneration before

                   modelBuilder.Entity<RoomAmenity>().HasKey(
                   roomAmenities => new
                   {
                       roomAmenities.AmenityId ,


                       roomAmenities.RoomId
                   }
                ) ;


                 modelBuilder.Entity<HotelRoom>().HasKey(
                  hotelRoom => new { 

                   hotelRoom.HotelId,

                   hotelRoom.RoomId 
               }
               );


        }

     
        
        //6- we create clases and add the attriput intit then we add it here like this
        public DbSet<Hotel> hotel { get; set; }

        public DbSet<Room> room { get; set; }

        public DbSet<Amenities> amenities { get; set; } 

        public DbSet <RoomAmenity> roomAmenities { get; set; }
        public DbSet <HotelRoom> hotelRooms { get; set; }




    }
}

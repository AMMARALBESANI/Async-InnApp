# Async-InnApp

## Introduction
Async-Inn-App is a .NET Core Web Application designed to create an API server. API services within this application provide a way for the application to communicate with a server-side system in order to retrieve and update data. API as a Service refers to a platform or tool that assists in the creation and deployment of API services. By utilizing EF Core (Entity Framework), developers can leverage an object-relational mapper (O/RM) that enables them to interact with a database using .NET objects. This eliminates the need for writing extensive data-access code typically required in such scenarios.
## Async-Inn Hotel database ERD diagram
![](./Async-demo.png)

## Packages and Tools

Create a new Empty .NET Core Web Application Setup Entity Framework Install the Entity Framework Dependencies for your app

 1-From Manage NuGet Packages Add:

- Microsoft.EntityFrameworkCore.SqlServer

- Microsoft.EntityFrameworkCore.Tools

2-Install ef command line tool

-From a terminal

- dotnet tool install --global dotnet-ef


## Data Models and SQL Tables
Tell now this project have 3 models present database table for the database digram


Hotel Class : Hotels: Hotels can have multiple rooms and are connected to those rooms through the HotelRoom table.
```b
public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
```

Room Class : Rooms are not specific rooms, but more like room types. Thus, a Hotel can have multiple Rooms, and a Room can belong to many Hotel locations. Rooms are related to Hotels through the HotelRoom table.
```b public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }
    }
 ```
Amenity Class : The Amenities table holds room features like AC, Coffee maker, etc. An amenity type can belong to many different rooms, and a room can have many different amenities. This many:many relationship is captured in the RoomAmenities join table.
```b  public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
```


## Seeding data
Seed data is data that you populate the database with at the time it is created. You use seeding to provide initial values for lookup lists.

-Add default data for all three of your simple models

-Hotels seed data

```b
modelBuilder.Entity<Hotel>().HasData(
                   new Hotel() {Id=1 , Name= "Async Inn" , City="Paris" , Country ="France" , State =" Paris" , StreetAdress = "Paris-France" , Phone ="00560078"},
                   new Hotel() {Id=2 , Name= "Async Inn" , City="Amman" , Country ="Jordan" , State =" Amman" , StreetAdress = "DownTawn" , Phone ="00962788996677"},
                   new Hotel() {Id=3 , Name= "Async Inn" , City="Qairo" , Country ="Egypt" , State ="Qairo" , StreetAdress = "SalahSalem" , Phone ="0156005098"}
                );
```


- Rooms seed data

```b
            modelBuilder.Entity<Room>().HasData(
              new Room() { Id = 1, Name = "RainTrain", layout = 2 },
              new Room() { Id = 2, Name = "GreenForest", layout = 1 },
              new Room() { Id = 3, Name = "RainTrain", layout = 3 }
            );

```

   -Amenities seed data

```b
            
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities() { Id=1, Name="Ac"},
                new Amenities() { Id=2, Name="CoffeMaker"},
                new Amenities() { Id=3, Name="Sawna"}
                );
 ```

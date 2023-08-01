namespace HotelAppDemo.Model.DTO
{
    public class RoomDTO
    {
       
            public int ID { get; set; }
            public string Name { get; set; }
            public int Layout { get; set; }
            public List<AmenitiesDTO> Amenities { get; set; }
        
    }
}

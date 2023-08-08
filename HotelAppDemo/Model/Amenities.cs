namespace HotelAppDemo.Model
{
    public class Amenities
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<RoomAmenity>? RoomAmenities { get; set; }
    }
}

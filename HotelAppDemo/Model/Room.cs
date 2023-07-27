using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAppDemo.Model
{
    public class Room
    {
        public int Id { get; set; } 

        public string Name { get; set; }    

        public int layout { get; set; }

        [NotMapped]
        public List<RoomAmenity> RoomAmenities { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }
    }
}

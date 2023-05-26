using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel? Hotels { get; set; }
        public int Price { get; set; }
        public String? Type { get; set; }
        public int Sharing { get; set; }
    }
}

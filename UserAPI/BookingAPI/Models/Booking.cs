using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }


        [Required]
        public int HotelID { get; set; }


        public string? HotelBranch { get; set; }

        [Required]
        public int RoomID { get; set; }


        [Required]
        public string? CustomerName { get; set; }


        [Required]
        public DateTime CheckInDate { get; set; }


        [Required]
        public DateTime CheckOutDate { get; set; }



    }
}

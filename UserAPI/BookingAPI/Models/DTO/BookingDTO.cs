using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models.DTO
{
    public class BookingDTO
    {
        public int BookingID { get; set; }


        [Required]
        public int HotelID { get; set; }


        public string? HotelBranch { get; set; }

        [Required]
        public int RoomID { get; set; }


        [Required]
        public string CustomerName { get; set; }


        [Required]
        public String CheckInDate { get; set; }


        [Required]
        public String CheckOutDate { get; set; }
    }
}

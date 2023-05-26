using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string? HotelBranch { get; set; }
        public string? HotelPhoneNumber{ get; set; }
        public string? HotelLocation { get; set; }
        public int? HotelRating { get; set; }
    }
}

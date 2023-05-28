namespace HotelAPI.Models.DTO
{
    public class PriceFilteredDataDTO
    {
        public int HotelId { get; set; }
        public string? HotelBranch { get; set; }
        public string? HotelPhoneNumber { get; set; }
        public string? HotelLocation { get; set; }
        public int? HotelRating { get; set; }
        public int RoomId { get; set; }
        public int Price { get; set; }
        public String? Type { get; set; }
        public int Sharing { get; set; }
    }
}

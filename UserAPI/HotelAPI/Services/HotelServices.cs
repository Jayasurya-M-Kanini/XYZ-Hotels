using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;

namespace HotelAPI.Services
{
    public class HotelServices
    {
        private readonly IBaseCRUD<int, Hotel> _hotelRepo;
        private readonly IBaseCRUD<int, Rooms> _roomRepo;

        public HotelServices(IBaseCRUD<int, Hotel> hotelRepo, IBaseCRUD<int, Rooms> roomRepo)
        {
            _hotelRepo = hotelRepo;
            _roomRepo = roomRepo;
        }


    public Hotel AddHotel(Hotel hotel)
    {
        var hotels = _hotelRepo.Add(hotel);
        if (hotels != null)
        {
            return hotels;
        }
        return null;
    }
        public List<Hotel> GetAllHotels()
        {
            var hotels = _hotelRepo.GetAll().ToList();
            if (hotels.Count > 0)
                return hotels;
            return null;
        }

        public Hotel GetHotelById(IdDTO hotelId)
        {
            var hotels = _hotelRepo.Get(hotelId.Id);
            if (hotels != null)
                return hotels;
            return null;
        }

        public Hotel DeleteHotel(IdDTO hotelId)
        {
            var hotels = _hotelRepo.Delete(hotelId.Id);
            if (hotels != null)
                return hotels;
            return null;
        }

        public Hotel Update(Hotel hotel)
        {
            var myHotel = _hotelRepo.Update(hotel);
            if (myHotel != null)
                return myHotel;
            return null;
        }

        public Rooms AddRoom(Rooms room)
        {
        var hotels = _hotelRepo.GetAll();
        var hotel = hotels.FirstOrDefault(h => h.HotelId == room.HotelId);
        var rooms = _roomRepo.Add(room);
        if (rooms != null && hotel != null)
            return rooms;
        return null;
        }

        public List<Rooms> GetAllRooms()
        {
            var rooms = _roomRepo.GetAll().ToList();
            if (rooms.Count > 0)
                return rooms;
            return null;
        }

        //Available rooms from each hotel
        public int RoomCount(IdDTO hotelId)
        {
            var hotels = _hotelRepo.GetAll().ToList();
            int roomsCount = hotels.Where(h => h.HotelId == hotelId.Id).Count();
            return roomsCount;
        }

        //Filter by location
        public List<Hotel> FilterHotelByLocation(LocationSearchDTO locationDTO)
        {
            var hotels = _hotelRepo.GetAll().ToList();
            var myHotels = hotels.Where(h => h.HotelLocation == locationDTO.Location).ToList();
            if (myHotels.Count > 0)
                return myHotels;
            return null;
        }

        //Search by Hotel branch
        public List<Rooms> SearchHotelByBranch(BranchSearchDTO branchDTO)
        {
            var hotels= _hotelRepo.GetAll().ToList();
            var rooms = _roomRepo.GetAll().ToList();
            var myHotel = hotels.FirstOrDefault(h => h.HotelBranch == branchDTO.Branch); 
            var myRooms = rooms.Where(r => r.HotelId == myHotel.HotelId).ToList();
            if (myRooms.Count > 0)
                return myRooms;
            return null;
        }

        //Filter Room by type
        public List<Rooms> FilterRoomByType(IdDTO hotelId,RoomTypeDTO typeDTO)
        {
            var rooms = _roomRepo.GetAll().ToList();
            var myRooms = rooms.Where(h => h.HotelId == hotelId.Id && h.Type==typeDTO.RoomType).ToList();
            if (myRooms.Count > 0)
                return myRooms;
            return null;
        }
    }
}

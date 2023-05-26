using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using System.Diagnostics;

namespace HotelAPI.Services
{
    public class HotelRepo : IBaseCRUD<IdDTO,Hotel>
    {
        private readonly HotelContext _context;

        public HotelRepo(HotelContext context)
        {
            _context = context;
        }
        public Hotel Add(Hotel item)
        {
            try
            {
                _context.Hotels.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public Hotel Delete(IdDTO idDto)
        {
            try
            {
                var hotel = _context.Hotels.FirstOrDefault(u => u.HotelId == idDto.Id);
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
                return hotel;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public Hotel Get(IdDTO idDto)
        {
            var hotel = _context.Hotels.FirstOrDefault(u => u.HotelId == idDto.Id);
            if(hotel == null)
            {
                return null;
            }
            return hotel;
        }

        public ICollection<Hotel> GetAll()
        {
            var hotel = _context.Hotels.ToList();
            if (hotel.Count > 0)
                return hotel;
            return null;
        }

        public Hotel Update(Hotel item)
        {
            var hotel = _context.Hotels.FirstOrDefault(u => u.HotelId == item.HotelId);
            if (hotel != null)
            {
                hotel.HotelBranch = item.HotelBranch;
                hotel.HotelPhoneNumber= item.HotelPhoneNumber;
                hotel.HotelLocation= item.HotelLocation;
                _context.Hotels.Update(hotel);
                _context.SaveChanges();
                return hotel;
            }
            else
            {
                return null;
            }
        }
    }
}

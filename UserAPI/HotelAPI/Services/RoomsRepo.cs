using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using System.Diagnostics;

namespace HotelAPI.Services
{
    public class RoomsRepo : IBaseCRUD<IdDTO, Rooms>
    {
        private readonly HotelContext _context;

        public RoomsRepo(HotelContext context)
        {
            _context = context;
        }
        public Rooms Add(Rooms item)
        {
            try
            {
                _context.Room.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public Rooms Delete(IdDTO idDTO)
        {
            try
            {
                var room = _context.Room.FirstOrDefault(u => u.RoomId == idDTO.Id);
                _context.Room.Remove(room);
                _context.SaveChanges();
                return room;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public Rooms Get(IdDTO idDTO)
        {
            var room = _context.Room.FirstOrDefault(u => u.RoomId == idDTO.Id);
            if (room == null)
            {
                return null;
            }
            return room;
        }

        public ICollection<Rooms> GetAll()
        {
            var rooms = _context.Room.ToList();
            if (rooms.Count > 0)
                return rooms;
            return null;
        }

        public Rooms Update(Rooms item)
        {
            var room = _context.Room.FirstOrDefault(u => u.RoomId == item.RoomId);
            if (room != null)
            {
                room.Price = item.Price;
                room.Type= item.Type;
                room.Sharing=item.Sharing;
                _context.Room.Update(room);
                _context.SaveChanges();
                return room;
            }
            else
            {
                return null;
            }
        }
    }
}

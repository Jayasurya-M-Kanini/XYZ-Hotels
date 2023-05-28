using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTO;

namespace BookingAPI.Services
{
    public class BookingServices
    {
        private readonly IBaseCRUD<IdDTO,Booking> _bookingRepo;

        public BookingServices(IBaseCRUD<IdDTO, Booking> bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

            public Booking BookHotel(BookingDTO bookingDTO)
            {
                // Parse check-in and check-out dates
                if (!DateTime.TryParseExact(bookingDTO.CheckInDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedCheckInDate)
                    || !DateTime.TryParseExact(bookingDTO.CheckOutDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedCheckOutDate))
                {
                    return null;
                }

                // Validate if the same hotel has an existing reservation with overlapping dates
                if (IsHotelAvailable(bookingDTO.HotelID, bookingDTO.RoomID, parsedCheckInDate, parsedCheckOutDate))
                {
                    var booking= new Booking();
                    booking.HotelID = bookingDTO.HotelID;
                    booking.RoomID = bookingDTO.RoomID;
                    booking.HotelBranch= bookingDTO.HotelBranch;
                    booking.BookingID = bookingDTO.BookingID;
                    booking.CheckInDate= parsedCheckInDate;
                    booking.CheckOutDate= parsedCheckOutDate;
                    var myBooking=_bookingRepo.Add(booking);
                    if(myBooking != null)
                    {
                        return myBooking;
                    }
                        return null;
                }
                return null;
            }

            public Booking CancelReservation(IdDTO bookingID)
            {
                var bookings=_bookingRepo.Delete(bookingID);
            
                if (bookings != null)
                {
                return bookings;
                }
                return null;
            }

        public Booking GetByID(IdDTO idDTO)
        {
            var booking = _bookingRepo.Get(idDTO);
            if (booking != null)
                return booking;
            return null;
        }

        public Booking Update(BookingDTO bookingDTO)
        {
            var booking = new Booking();
            booking.HotelID = bookingDTO.HotelID;
            booking.RoomID = bookingDTO.RoomID;
            booking.HotelBranch = bookingDTO.HotelBranch;
            booking.BookingID = bookingDTO.BookingID;
            if (!DateTime.TryParseExact(bookingDTO.CheckInDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedCheckInDate)
            || !DateTime.TryParseExact(bookingDTO.CheckOutDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedCheckOutDate))
            {
                return null;
            }
            booking.CheckInDate = parsedCheckInDate;
            booking.CheckOutDate = parsedCheckOutDate;
            var myBooking = _bookingRepo.Update(booking);
            if (booking != null)
                return booking;
            return null;
        }

        public List<Booking> GetAll()
        {
            var booking = _bookingRepo.GetAll().ToList();
            if (booking != null)
                return booking;
            return null;
        }
        public List<Booking> BookedRoomsByHotel(IdDTO idDTO)
        {
            var booking = _bookingRepo.GetAll().ToList();
            var mybookedRooms = booking.Where(R => R.HotelID == idDTO.Id).ToList();
            if (mybookedRooms != null)
                return mybookedRooms;
            return null;
        }


        private bool IsHotelAvailable(int HotelID,int RoomID, DateTime checkInDate, DateTime checkOutDate)
            {
                var myBookings=_bookingRepo.GetAll().ToList();
                foreach(var booking in myBookings) 
                {
                    if (booking.HotelID.Equals(HotelID) && booking.RoomID.Equals(RoomID) &&
                        (checkInDate >= booking.CheckInDate && checkInDate <= booking.CheckOutDate ||
                         checkOutDate >= booking.CheckInDate && checkOutDate <= booking.CheckOutDate))
                    {
                        return false;
                    }
                }
                return true;
            }
    }
}

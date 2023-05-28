using BookingAPI.Models;
using BookingAPI.Models.DTO;
using BookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingServices _bookingServices;

        public BookingsController(BookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        [Authorize]
        public ActionResult<Booking> Room_Booking(BookingDTO bookingDTO)
        {
            var myReservation = _bookingServices.BookHotel(bookingDTO);
            if (myReservation != null)
                return Created("Room Booked Successfully", myReservation);
            return BadRequest("Unable to Book Room");
        }


        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]
        [Authorize]
        public ActionResult<Booking> Cancelling_Booking(IdDTO idDTO)
        {
            var reservation = _bookingServices.CancelReservation(idDTO);
            if (reservation != null)
                return Ok(reservation);
            return BadRequest($"There is No Bookings for the id: {idDTO.Id}");
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        [Authorize]
        public ActionResult<Booking> Get_Booking(IdDTO idDTO)
        {
            var reservation = _bookingServices.GetByID(idDTO);
            if (reservation != null)
                return Ok(reservation);
            return NotFound( $"There is No Bookings for the id: {idDTO.Id}");
        }

        [ProducesResponseType(typeof(List<Booking>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]
        [Authorize]
        public ActionResult<Booking> Get_All_Bookings()
        {
            var reservations = _bookingServices.GetAll();
            if (reservations != null)
                return Ok(reservations);
            return NotFound("No Bookings Available");
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        [Authorize]
        public ActionResult<Booking> Update_Booking(BookingDTO bookingDTO)
        {
            var newReservation = _bookingServices.Update(bookingDTO);
            if (newReservation != null)
                return Ok(newReservation);
            return BadRequest($"There is No Bookings for the id: {bookingDTO.BookingID}");
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        [Authorize]
        public ActionResult<Booking> ViewBookingByHotelID(IdDTO idDTO)
        {
            var newReservation = _bookingServices.BookedRoomsByHotel(idDTO);
            if (newReservation != null)
                return Ok(newReservation);
            return BadRequest($"There is No Bookings for the id: {idDTO.Id}");
        }
    }
}

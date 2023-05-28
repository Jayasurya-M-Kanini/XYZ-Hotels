using HotelAPI.Models;
using HotelAPI.Models.DTO;
using HotelAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelServices _hotelServices;

        public HotelController(HotelServices hotelServices)
        {
            _hotelServices = hotelServices;
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Add Hotel")]
        [Authorize(Roles="Staff")]
        [Authorize]
        public ActionResult<Hotel> AddHotel(Hotel hotel)
        {
            Hotel newHotel = _hotelServices.AddHotel(hotel);
            if (newHotel == null)
                return BadRequest("Unable to add Hotel");
            return Created("Hotel Added Successfully", newHotel);
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("View Available Hotels")]
        [Authorize]
        public ActionResult<List<Hotel>> GetAllHotel()
        {
            var hotels = _hotelServices.GetAllHotels();
            if (hotels != null)
                return Ok(hotels);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Hotels available");
        }


        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("View Hotel by HotelID")]
        [Authorize]
        public ActionResult<Hotel> GetHotelByID(IdDTO idDTO)
        {
            var hotel = _hotelServices.GetHotelById(idDTO);
            if (hotel != null)
                return Ok(hotel);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Hotel available");
        }


        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete("Delete Hotel by HotelID")]
        [Authorize(Roles = "Staff")]
        [Authorize]
        public ActionResult<Hotel> DelteHotelByID(IdDTO idDTO)
        {
            var hotel = _hotelServices.DeleteHotel(idDTO);
            if (hotel != null)
                return Ok(hotel);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Hotel available");
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut("Update Hotel by HotelID")]
        [Authorize(Roles = "Staff")]
        [Authorize]
        public ActionResult<Hotel> UpdateHotel(Hotel hotel)
        {
            var myhotel = _hotelServices.Update(hotel);
            if (myhotel != null)
                return Ok(myhotel);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("Hotel Not updated");
        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Add Rooms")]
        [Authorize(Roles = "Staff")]
        [Authorize]
        public ActionResult<Rooms> AddRoom(Rooms room)
        {
            var myroom = _hotelServices.AddRoom(room);
            if (myroom != null)
                return Created("Room created Successfully", myroom);
            //return BadRequest(new Error(2, "Unable to add Room"));
            return BadRequest("Unable to add Room");
        }

        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("View All Available Rooms")]
        [Authorize]
        public ActionResult<List<Rooms>> GetAllRooms()
        {
            var myroom = _hotelServices.GetAllRooms();
            if (myroom != null)
                return Ok(myroom);
            //return BadRequest(new Error(2, "Unable to add Room"));
            return BadRequest("Unable to add Room");
        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("View Rooms By Hotel ID")]
        [Authorize]
        public ActionResult<List<Rooms>> ViewRoomsByHotelID(IdDTO idDTO)
        {
            var rooms = _hotelServices.GetRoomByHotelID(idDTO);
            if (rooms != null)
                return Ok(rooms);
            //return NotFound(new Error(4, "No Rooms available"));
            return BadRequest("No available rooms");
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Search Hotel by Location")]
        [Authorize]
        public ActionResult<List<Hotel>> SearchHotelByLocation(LocationSearchDTO locationDTO)
        {
            var hotels = _hotelServices.FilterHotelByLocation(locationDTO);
            if (hotels != null)
                return Ok(hotels);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Hotels available in this location");
        }

        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Search Hotel by Branch")]
        [Authorize]
        public ActionResult<List<Rooms>> GetRoomsByHotelBranch(BranchSearchDTO branchDTO)
        {
            var rooms = _hotelServices.SearchRoomsByHotelBranch(branchDTO);
            if (rooms != null)
                return Ok(rooms);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Rooms available");

        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Filter Rooms by Type")]
        [Authorize]
        public ActionResult<List<Rooms>> FilterRoomsByType(RoomTypeDTO roomType)
        {
            var rooms = _hotelServices.FilterRoomByType(roomType);
            if (rooms != null)
                return Ok(rooms);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Rooms available");

        }

        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Filter Rooms by Sharing")]
        [Authorize]
        public ActionResult<List<Rooms>> FilterRoomsBySharing(RoomSharingDTO roomSharing)
        {
            var rooms = _hotelServices.FilterRoomBySharing(roomSharing);
            if (rooms != null)
                return Ok(rooms);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Rooms available");
        }



        [ProducesResponseType(typeof(PriceFilteredDataDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Filter Rooms by Price")]
        [Authorize]
        public ActionResult<List<PriceFilteredDataDTO>> FilterRoomsByPriceWithoutID(PriceRangeDTO priceRange)
        {
            var rooms = _hotelServices.FilterRoomByPriceWithoutID(priceRange);
            if (rooms != null)
                return Ok(rooms);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Rooms available");
        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Available Rooms Count")]
        [Authorize]
        public ActionResult<int> GetAvailableRoomsCount(IdDTO idDTO)
        {
            int roomsCount = _hotelServices.RoomCount(idDTO);
            if (roomsCount >= 0)
                return Ok(roomsCount);
            //return NotFound(new Error(4, "No Rooms available"));
            return NotFound("No Rooms available");
        }
    }
}

using HotelAPI.Models;
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


        [HttpPost("Add Hotel")]
        //[Authorize(Policy = "StaffOnly")]
        [Authorize]
        public ActionResult<Hotel> AddHotel(Hotel hotel)
        {
            Hotel newHotel = _hotelServices.AddHotel(hotel);
            if (newHotel == null)
                return BadRequest("Unable to add Pizza");
            return Created("Pizza Added Successfully", newHotel);
        }
    }
}

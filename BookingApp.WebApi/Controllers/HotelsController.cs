using BookingApp.Business.Operations.Hotel;
using BookingApp.Business.Operations.Hotel.Dtos;
using BookingApp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BookingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotel(id);

            if (hotel != null)
                return Ok(hotel);
            else
                return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotel = await _hotelService.GetHotels();

            return Ok(hotel);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddHotel(AddHotelRequest request)
        {
            var addHotelDto = new AddHotelDto
            {
                Name = request.Name,
                Stars = request.Stars,
                Location = request.Location,
                AccomodationType = request.AccomodationType,
                FeatureIds = request.FeatureIds
            };
            var result = await _hotelService.AddHotel(addHotelDto);

            if (result.IsSucceed)
                return Ok(result);
            else
                return BadRequest(result.Message);

        }
        [HttpPatch("{id}/stars")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdjustHotelStars(int id, int changeTo)
        {
            var result = await _hotelService.AdjustHotelStars(id, changeTo);

            if (!result.IsSucceed)
                return BadRequest(result.Message);
            else
                return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var result = await _hotelService.DeleteHotel(id);
            if (!result.IsSucceed)
                return BadRequest(result.Message);
            else
                return Ok(result);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateHotel(int id, UpdateHotelRequest request)
        {
            var updateHotelDto = new UpdateHotelDto
            {
                Id = id,
                Name = request.Name,
                Stars = request.Stars,
                Location = request.Location,
                AccomodationType = request.AccomodationType,
                FeatureIds = request.FeatureIds
            };

            var result = await _hotelService.UpdateHotel(updateHotelDto);
            if (!result.IsSucceed)
                return NotFound(result.Message);
            else
                return await GetHotel(id);
        }
    }
}

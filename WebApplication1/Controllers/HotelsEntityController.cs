using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing_API.Data;
using WebApplication1.Data;
using HotelListing_API.Contracts;
using AutoMapper;
using HotelListing_API.Models.Country;

namespace HotelListing_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsEntityController : ControllerBase
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IMapper _mapper;

        public HotelsEntityController(IHotelsRepository hotelsRepository,IMapper _mapper)
        {
            this._hotelsRepository = hotelsRepository;
            this._mapper = _mapper;
        }

        // GET: api/HotelsEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            var hotels = await _hotelsRepository.GetAllAsync();
            return _mapper.Map<List<HotelDTO>>(hotels);
        }

        // GET: api/HotelsEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return _mapper.Map<HotelDTO>(hotel);
        }

        // PUT: api/HotelsEntity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDTO hotelDTO)
        {
            if (id != hotelDTO.Id)
            {
                return BadRequest();
            }

            var hotel = await _hotelsRepository.GetAsync(id);
            if(hotel == null)
            {
                return NotFound();
            }

            _mapper.Map(hotelDTO,hotel);

            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelsEntity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateCountryDTO hotelDTO)
        {
            var hotel = _mapper.Map<Hotel>(hotelDTO);
            await _hotelsRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/HotelsEntity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }
    }
}

using Backend_WebAPI_Task1.DAL;
using Backend_WebAPI_Task1.DTOs.Gameshop;
using Backend_WebAPI_Task1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameshopsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public GameshopsController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Gameshop gameshop = _context.Gameshops.FirstOrDefault(g => g.Id == id);
            if (gameshop is null) return NotFound();

            GameshopGetDto dto = new GameshopGetDto
            {
                Id = gameshop.Id,
                Title = gameshop.Title,
                Address = gameshop.Address,
                PriceRange = gameshop.PriceRange
            };

            return Ok(dto);
        }
        [HttpGet("")]
        public IActionResult GetAll(int page = 1, string search = null)
        {
            var query = _context.Gameshops.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Title.Contains(search));
            }

            GameshopListDto dto = new GameshopListDto
            {
                GameshopListItemDtos = query
                .Select(g => new GameshopListItemDto { Id = g.Id, Address = g.Address, PriceRange = g.PriceRange, Title = g.Title })
                .Skip((page-1)*5).Take(5).ToList(),
                TotalGamesCount=query.Count()
                
            };
            return Ok(dto);

        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(GameshopPostDto dto)
        {
            if (dto is null) return NotFound();

            Gameshop gameshop = new Gameshop
            {
                Title = dto.Title,
                Address=dto.Address,
                PriceRange=dto.PriceRange,
                
            };
            await _context.Gameshops.AddAsync(gameshop);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created,gameshop);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, GameshopPostDto dto)
        {
            Gameshop existed = _context.Gameshops.FirstOrDefault(g => g.Id == id);
            if (existed is null) return NotFound();

            _context.Entry(existed).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return Ok(existed);
        }
    }
}

using Backend_WebAPI_Task1.DAL;
using Backend_WebAPI_Task1.DTOs;
using Backend_WebAPI_Task1.DTOs.VideoGame;
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
    public class VideoGamesController : ControllerBase
    {
      
        private readonly APIDbContext _context;

        public VideoGamesController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0) return NotFound();
            VideoGame videoGame = _context.VideoGames.FirstOrDefault(v=>v.Id==id);

            VideoGameGetDto videoGameDto = new VideoGameGetDto
            {
                Id=videoGame.Id,
                Company=videoGame.Company,
                Name=videoGame.Name,
                Price=videoGame.Price,
                IsVisible=videoGame.IsVisible
            };
            if (videoGame is null) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(videoGameDto);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll(int page = 1,string search = null)
        {

            var query = _context.VideoGames.Where(v=>v.IsVisible==true).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Name.Contains(search));
            }
            VideoGameListDto dto = new VideoGameListDto
            {
                VideoGameListItemDtos = query
                .Select(v => new VideoGameListItemDto { Id = v.Id, Company = v.Company, Name = v.Name, Price = v.Price })
                .Skip((page - 1) * 4).Take(4).ToList(),
                TotalCount=query.Count()

            };
            return Ok(dto);
        }
         
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(VideoGamePostDto videoGameDto)
        {
            if (videoGameDto is null) return NotFound();
            VideoGame videoGame = new VideoGame
            {
                Company = videoGameDto.Company,
                Name = videoGameDto.Name,
                Price = videoGameDto.Price,
                

            };
            await _context.VideoGames.AddAsync(videoGame);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, videoGame);
        }

        [HttpPut("update/{id}")]
       
        public async Task<IActionResult> Update(int id,VideoGamePostDto videoGameDto)
        {
            if (id == 0) return BadRequest();
            VideoGame existed = _context.VideoGames.FirstOrDefault(v => v.Id == id);
            if (existed is null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(videoGameDto);

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK,existed);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            VideoGame existed = _context.VideoGames.FirstOrDefault(v => v.Id == id);
            if (existed is null) return NotFound();
            _context.VideoGames.Remove(existed);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPatch]
        [Route("change/{id}")]
        public IActionResult Change(int id, bool status)
        {
            if (id == 0) return BadRequest();
            VideoGame existed = _context.VideoGames.FirstOrDefault(v => v.Id == id);
            if (existed is null) return NotFound();

            existed.IsVisible = status;
            _context.SaveChanges();
            return Ok(existed);
        }
    }
}

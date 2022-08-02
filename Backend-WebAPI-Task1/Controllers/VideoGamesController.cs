using Backend_WebAPI_Task1.DAL;
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
            if (videoGame is null) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(videoGame);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
        
            return Ok(_context.VideoGames.Where(v=>v.IsVisible==true).ToList());
        }

        [HttpPost]
        [Route("create")]
         public IActionResult Create(VideoGame videoGame)
        {
            if (videoGame is null) return NotFound();
            _context.VideoGames.Add(videoGame);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created,videoGame);
        }

        [HttpPut("update/{id}")]
       
        public async Task<IActionResult> Update(int id,VideoGame videoGame)
        {
            if (id == 0) return BadRequest();
            VideoGame existed = _context.VideoGames.FirstOrDefault(v => v.Id == id);
            if (existed is null) return NotFound();
            existed.Company = videoGame.Company;
            existed.Name = videoGame.Name;
            existed.Price = videoGame.Price;

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

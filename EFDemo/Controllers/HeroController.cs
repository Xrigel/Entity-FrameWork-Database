using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public HeroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dataContext.Heroes.ToListAsync());
        }
        [HttpPost]

        public async Task<IActionResult> AddHero(HeroModel hero)
        {
            _dataContext.Heroes.Add(hero);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Heroes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            var hero =await _dataContext.Heroes.FindAsync(id);
            if (hero==null)
            {
                return BadRequest("Hero not found");
            }
            return Ok(hero);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHero(HeroModel requestedHero)
        {
            var hero = await _dataContext.Heroes.FindAsync(requestedHero.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            hero.Name = requestedHero.Name;
            hero.FirstName = requestedHero.FirstName;
            hero.LastName = requestedHero.LastName;
            hero.Place = requestedHero.Place;
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Heroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hero = await _dataContext.Heroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            _dataContext.Heroes.Remove(hero);
            await _dataContext.SaveChangesAsync();
            
            
            return Ok(await _dataContext.Heroes.ToListAsync());
        }
    }
}

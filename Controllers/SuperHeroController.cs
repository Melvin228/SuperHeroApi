using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        public SuperHeroController(DataContext dataContext)
        {
            DataContext = dataContext;
        }   
        private static List<SuperHero> heroes = new List<SuperHero>
        {
                new SuperHero  {
                Id=1,
                Name="SpiderMan",
                FirstName="Peter",
                LastName="Parker",
                Place="New York City" },
                new SuperHero
                {
                    Id = 2,
                    Name = "SandMan",
                    FirstName = "Sand",
                    LastName = "Man",
                    Place = "New York City",
                }
         };

        public DataContext DataContext { get; }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            //return  

            // for database 
           // return Ok(await _context.SuperHeroes.ToListAsync());
            return Ok(heroes);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            //database
            // var hero = await _context.SuperHeroes.FindAsync(id);
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            //database
            // _context.SuperHeroes.Add(heroes)
            //await _context.SaveChangesAsync();
            //return Ok(await _context.SuperHeroes.ToListAsync());
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {

            //Database
            // var dbhero = await context.SuperHero.FindAsync(request.Id);
            // if (dbhero==null) { return BadRequest("Hero Not Found");}

           
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            //await _context.SaveChangesAsync().
            //return Ok(await _context.SuperHeroes.ToListAsync());

            return Ok(hero);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            // database
            // var hero = await _context.SuperHeroes.FindAsync(id)


            var hero = heroes.Find(h => h.Id == id);

            if(hero == null)
            {
                return BadRequest("Hero not found");
            }

            // _context.SuperHeroes.Remove(hero);

            //await _context.SaveChangesAsync();

            //return Ok(await _context.SuperHeroes.TOListAsync());
            heroes.Remove(hero);

            return NoContent();
        }
    }
}


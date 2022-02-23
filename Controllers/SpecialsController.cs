using BlazingPizza.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlazingPizza.Controllers
{
    [Route("specials")]
    [ApiController]
    public class SpecialsController : ControllerBase
    {
        private readonly PizzaStoreContext _context;
        public SpecialsController(PizzaStoreContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            var response = new List<PizzaSpecial>();
            response = (await _context.Specials.ToListAsync()).OrderBy(s => s.BasePrice).ToList();
            return response;
        }
    }
}

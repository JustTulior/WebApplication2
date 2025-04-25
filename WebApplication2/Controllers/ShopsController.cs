using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Shops;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        DatabaseContext db;
        public ShopsController(DatabaseContext context)
        {
            db = context;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shops.Shops>>> Get()
        {
            return await db.Shops.AsNoTracking().ToListAsync();
        }
    }
}

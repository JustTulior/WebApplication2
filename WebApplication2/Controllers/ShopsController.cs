using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Repositories;
using WebApplication2.Shops;

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopsRepository _shopsRepository;
        public ShopsController(IShopsRepository shopsRepository)
        {
            _shopsRepository = shopsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopsEntity>>> Get()
        {
            var shops = await _shopsRepository.Get();
            return Ok(shops);
        }
        [HttpGet("{id}")]

        public async Task <ActionResult<ShopsEntity>> GetById(int id)
        {
            var shop = await _shopsRepository.GetById(id);
            return Ok(shop);
        }
        [HttpPost]
        public async Task<ActionResult<ShopsEntity>> Add(ShopsEntity shopsEntity)
        {
            var shop = await _shopsRepository.Create(shopsEntity);
            return Ok(shop);
        }

    }
}

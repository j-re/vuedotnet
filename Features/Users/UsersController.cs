using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vue.Data;

namespace vue.Features.Users
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly VueContext _db;
        public UsersController(VueContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Users.ToListAsync());
        }
    }
}
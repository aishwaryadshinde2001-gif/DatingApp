using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
       [HttpGet]
       public async Task<ActionResult<List<Appuser>>> GetMembers()
        {
            var members = await context.users.ToListAsync();
            return members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appuser>> GetMember(string id)
        {
            var member = await context.users.FirstOrDefaultAsync(x => x.Id ==id );
            if(member == null)
            {
                return NotFound();
            }
            return member;
        }
    }
}

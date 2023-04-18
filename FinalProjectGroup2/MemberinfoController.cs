using FinalProjectGroup2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectGroup2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MemberinfoController : ControllerBase
    {
        private readonly DataContext _context;

        public MemberinfoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Memberinfo>>> GetMemberinfo(int? id)
    }
}
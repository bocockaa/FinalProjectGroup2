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
        private MemberinfoContext _context;

        public MemberinfoController(MemberinfoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMemberinfo(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.Memberinfos.Take(5).ToListAsync();
            }
            else
            {
                return await _context.Memberinfos.Where(TaskCompletionSource => TaskCompletionSource.Id == id).ToListAsync();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberinfo(int id)
        {
            var memberInfos = await _context.Memberinfos.FindAsync(id);
            
            if (memberInfos == null)
            {
                return NotFound();
            }
            
            return memberInfo;
        }

        [HttpPost]
        public async Task<ActionResult<Member>> PostMemberinfo(Member memberInfos)
        {
            _context.MemberInfos.Add(memberInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMemberInfos), new {id = memberInfos.Id}, memberInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberinfo(int id, Member memberInfo)
        {
            if (id != memberInfo.Id)
            {
                return Badrequest();
            }

            _context.Entry(memberInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberinfo(int id)
        {
            var memberInfo = await _context.MemberInfos.FindAsync(id);

            if (memberInfo == null)
            {
                return NotFound();
            }

            _context.MemberInfos.Remove(memberInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
    
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAT250_REST.Data;
using DAT250_REST.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace DAT250_REST.Controllers
{
    [Authorize ]
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PollsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Polls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poll>>> GetPolls()
        {
            return await _context.Polls.Include(p => p.Options).
                ToListAsync();
        }

        // GET: api/Polls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poll>> GetPoll(string id)
        {
            var poll = await _context.Polls.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == id);

            if (poll == null)
            {
                return NotFound();
            }

            return poll;
        }

        // PUT: api/Polls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(string id, Poll poll)
        {
            if (id != poll.Id)
            {
                return BadRequest();
            }

            _context.Entry(poll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Polls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Poll>> PostPoll(PollDto pollDto)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var creator = await _context.Users.FindAsync(userId) ?? throw new InvalidOperationException("No user found with userid:" + userId);

            Poll poll = new()
            {
                Creator = creator,
                Question = pollDto.Question,
                ValidUntil = pollDto.ValidUntil,
                PublishedAt = pollDto.PublishedAt,
                Options = pollDto.Options
            };
            _context.Polls.Add(poll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoll", new { id = poll.Id }, poll);
        }

        // DELETE: api/Polls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoll(string id)
        {
            var poll = await _context.Polls.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PollExists(string id)
        {
            return _context.Polls.Any(e => e.Id == id);
        }

        public class PollDto
        {
            public required String Question { get; set; }
            public DateTime PublishedAt { get; set; }
            public DateTime ValidUntil { get; set; }
            public required List<VoteOption> Options { get; set; }
        }
    }
}

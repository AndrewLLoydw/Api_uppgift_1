#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_uppgift_1;
using Api_uppgift_1.Models.Entities;

namespace Api_uppgift_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandlerController : ControllerBase
    {
        private readonly SqlContext _context;

        public HandlerController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Handler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HandlerEntity>>> GetHandlers()
        {
            return await _context.Handlers.ToListAsync();
        }

        // GET: api/Handler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HandlerEntity>> GetHandlerEntity(int id)
        {
            var handlerEntity = await _context.Handlers.FindAsync(id);

            if (handlerEntity == null)
            {
                return NotFound();
            }

            return handlerEntity;
        }

        // PUT: api/Handler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHandlerEntity(int id, HandlerEntity handlerEntity)
        {
            if (id != handlerEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(handlerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HandlerEntityExists(id))
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

        // POST: api/Handler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HandlerEntity>> PostHandlerEntity(HandlerEntity handlerEntity)
        {
            _context.Handlers.Add(handlerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHandlerEntity", new { id = handlerEntity.Id }, handlerEntity);
        }

        // DELETE: api/Handler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHandlerEntity(int id)
        {
            var handlerEntity = await _context.Handlers.FindAsync(id);
            if (handlerEntity == null)
            {
                return NotFound();
            }

            _context.Handlers.Remove(handlerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HandlerEntityExists(int id)
        {
            return _context.Handlers.Any(e => e.Id == id);
        }
    }
}

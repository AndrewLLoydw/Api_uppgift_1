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
using Api_uppgift_1.Models;

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
        public async Task<ActionResult<IEnumerable<HandlerModel>>> GetHandlers()
        {
            var items = new List<HandlerModel>();

            foreach (var item in await _context.Handlers.ToListAsync())
                items.Add(new HandlerModel(item.Id, item.FirstName, item.LastName, item.Email));

            return items;
        }





        // GET: api/Handler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HandlerModel>> GetHandlerEntity(int id)
        {
            var handlerEntity = await _context.Handlers.FindAsync(id);

            if (handlerEntity == null)
            {
                return NotFound();
            }

            return new HandlerModel(handlerEntity.Id, handlerEntity.FirstName, handlerEntity.LastName, handlerEntity.Email);
        }





        // PUT: api/Handler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHandlerEntity(int id, HandlerUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var handlerEntity = await _context.Handlers.FindAsync(model.Id);
            handlerEntity.FirstName = model.FirstName;
            handlerEntity.LastName = model.LastName;
            handlerEntity.Email = model.Email;

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
        public async Task<ActionResult<HandlerModel>> PostHandlerEntity(CreateHandler model)
        {

            if (await _context.Handlers.AnyAsync(x => x.Email == model.Email))
                return Conflict();

            var handlerEntity = new HandlerEntity(model.FirstName, model.LastName, model.Email);

            _context.Handlers.Add(handlerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHandlerEntity", new { id = handlerEntity.Id }, new HandlerModel(handlerEntity.Id, handlerEntity.FirstName, handlerEntity.LastName, handlerEntity.Email));
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

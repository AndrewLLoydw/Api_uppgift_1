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
    public class OrderHandlerController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderHandlerController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/OrderHandler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHandlerEntity>>> GetOrderHandlers()
        {
            return await _context.OrderHandlers.ToListAsync();
        }

        // GET: api/OrderHandler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderHandlerEntity>> GetOrderHandlerEntity(int id)
        {
            var orderHandlerEntity = await _context.OrderHandlers.FindAsync(id);

            if (orderHandlerEntity == null)
            {
                return NotFound();
            }

            return orderHandlerEntity;
        }

        // PUT: api/OrderHandler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderHandlerEntity(int id, OrderHandlerEntity orderHandlerEntity)
        {
            if (id != orderHandlerEntity.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderHandlerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderHandlerEntityExists(id))
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

        // POST: api/OrderHandler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderHandlerEntity>> PostOrderHandlerEntity(OrderHandlerEntity orderHandlerEntity)
        {
            _context.OrderHandlers.Add(orderHandlerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderHandlerEntity", new { id = orderHandlerEntity.OrderId }, orderHandlerEntity);
        }

        // DELETE: api/OrderHandler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderHandlerEntity(int id)
        {
            var orderHandlerEntity = await _context.OrderHandlers.FindAsync(id);
            if (orderHandlerEntity == null)
            {
                return NotFound();
            }

            _context.OrderHandlers.Remove(orderHandlerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderHandlerEntityExists(int id)
        {
            return _context.OrderHandlers.Any(e => e.OrderId == id);
        }
    }
}

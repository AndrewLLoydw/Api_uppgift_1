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
    public class CustomerAddressController : ControllerBase
    {
        private readonly SqlContext _context;

        public CustomerAddressController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/CustomerAddress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerAddressEntity>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/CustomerAddress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAddressEntity>> GetCustomerAddressEntity(int id)
        {
            var customerAddressEntity = await _context.Addresses.FindAsync(id);

            if (customerAddressEntity == null)
            {
                return NotFound();
            }

            return customerAddressEntity;
        }

        // PUT: api/CustomerAddress/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerAddressEntity(int id, CustomerAddressEntity customerAddressEntity)
        {
            if (id != customerAddressEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerAddressEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAddressEntityExists(id))
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

        // POST: api/CustomerAddress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerAddressEntity>> PostCustomerAddressEntity(CustomerAddressEntity customerAddressEntity)
        {
            _context.Addresses.Add(customerAddressEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerAddressEntity", new { id = customerAddressEntity.Id }, customerAddressEntity);
        }

        // DELETE: api/CustomerAddress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAddressEntity(int id)
        {
            var customerAddressEntity = await _context.Addresses.FindAsync(id);
            if (customerAddressEntity == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(customerAddressEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerAddressEntityExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}

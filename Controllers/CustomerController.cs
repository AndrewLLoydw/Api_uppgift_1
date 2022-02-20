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
using Api_uppgift_1.Models.Create;
using Api_uppgift_1.Models.Update;

namespace Api_uppgift_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly SqlContext _context;

        public CustomerController(SqlContext context)
        {
            _context = context;
        }


        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            var items = new List<CustomerModel>();
            foreach (var item in await _context.Customers.Include(x => x.Address).ToListAsync())
            {
                items.Add
                    (new CustomerModel(item.Id, item.FirstName, item.LastName, item.Email,
                    new CustomerAddressModel(item.Address.StreetName, item.Address.PostalCode, item.Address.City, item.Address.Country)));
            }

            return items;
        }





        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

            if (customerEntity == null)
            {   
                return NotFound();
            }

            return 
                new CustomerModel(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email,
                new CustomerAddressModel(customerEntity.Address.StreetName, customerEntity.Address.PostalCode, customerEntity.Address.City, customerEntity.Address.Country));
        }





        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerEntity(int id, CustomerUpdate model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var customerEntity = await _context.Customers.FindAsync(model.Id);
            var customerAddressEntity = await _context.Addresses.FindAsync(model.Id);
            if (customerEntity == null || customerAddressEntity == null)
                return NotFound();

            customerEntity.FirstName = model.FirstName;
            customerEntity.LastName = model.LastName;
            customerEntity.Email = model.Email;
            customerEntity.Password = model.Password;
            customerAddressEntity.StreetName = model.StreetName;
            customerAddressEntity.PostalCode = model.PostalCode;
            customerAddressEntity.City = model.City;
            customerAddressEntity.Country = model.Country;
            

            _context.Entry(customerEntity).State = EntityState.Modified;
            _context.Entry(customerAddressEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEntityExists(id))
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





        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerEntity(CreateCustomer model)
        {
            if (await _context.Customers.AnyAsync(x => x.Email == model.Email))
                return Conflict();

            var customerEntity = new CustomerEntity(model.FirstName, model.LastName, model.Email, model.Password);

            var customerAddress = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode && x.City == model.City);
            if (customerAddress != null)
                customerEntity.AddressId = customerAddress.Id;

            else
                customerEntity.Address = new CustomerAddressEntity(model.StreetName, model.PostalCode, model.City, model.Country);

            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }





        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            var customerAddressEntity = await _context.Addresses.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            customerEntity.FirstName = "";
            customerEntity.LastName = "";
            customerEntity.Email = "";
            customerEntity.Password = "";
            customerAddressEntity.StreetName = "";
            customerAddressEntity.PostalCode = 0;
            customerAddressEntity.City = "";
            customerAddressEntity.Country = "";


            _context.Entry(customerEntity).State = EntityState.Modified;
            _context.Entry(customerAddressEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }








        private bool CustomerEntityExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}

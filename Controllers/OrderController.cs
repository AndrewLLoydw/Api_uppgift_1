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
    public class OrderController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderController(SqlContext context)
        {
            _context = context;
        }





        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders()
        {
            var items = new List<OrderModel>();
            var products = new List<ProductListModel>();
            foreach(var item in await _context.Orders.Include(x => x.Customer).Include(x => x.Products).ToListAsync())
            {
                items.Add(new OrderModel(item.Id, item.Created, item.Status, new CustomerModel(item.Customer.Id, item.Customer.FirstName, item.Customer.LastName, item.Customer.Email), new List<ProductListModel>(), item.OrderPrice));
            }

            return items;

        }





        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrder(int id)
        {
            var orderEntity = await _context.Orders.Include(x => x.Customer).Include(x => x.Products).FirstOrDefaultAsync();
            List<ProductListModel> products = new();

            foreach(var product in orderEntity.Products)
                products.Add(new ProductListModel(product.Id, product.ProductNumber, product.ProductName, product.ProductPrice));

            if (orderEntity == null)
            {
                return NotFound();
            }

            return new OrderModel(orderEntity.Id, orderEntity.Created, orderEntity.Status, new CustomerModel(orderEntity.Customer.Id, orderEntity.Customer.FirstName, orderEntity.Customer.LastName, orderEntity.Customer.Email), products, orderEntity.OrderPrice);
        }





        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEntity(int id, OrderEntity orderEntity)
        {
            if (id != orderEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntityExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderEntity>> PostOrderEntity(OrderEntity orderEntity)
        {
            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderEntity", new { id = orderEntity.Id }, orderEntity);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderEntityExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}

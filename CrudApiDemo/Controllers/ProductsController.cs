using Microsoft.AspNetCore.Mvc;
using CrudApiDemo.Data;
using CrudApiDemo.Models;

namespace CrudApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        // READ ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.ToList());
        }

        // READ BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updated)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;

            _context.SaveChanges();
            return Ok(product);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}
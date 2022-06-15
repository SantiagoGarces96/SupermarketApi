using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketApi.Models;

namespace SupermarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SuperMarketTecocContext _context;

        public ProductsController(SuperMarketTecocContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult GetProduct()
        {
            try
            {
                return Ok(_context.Products.ToList());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name ="GetProduct")]
        public ActionResult GetProduct(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(e => e.Id == id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProduct(int id,[FromBody] Product product)
        {
            try
            {

                if (product.Id == id)
                {
                    _context.Entry(product).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetProduct", new{id = product.Id}, product);
                }
            else
            {
                return BadRequest();    
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostProduct([FromBody]Product product)

        {
            try
            { 
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            { 
            var product = _context.Products.FirstOrDefault(e => e.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
          }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupermarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SuperMarketTecocContext context;
        public ProductController(SuperMarketTecocContext context)
        {
            this.context = context;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupermarketApi.Entities.Product>>> Get()
        {
            var list = new List<SupermarketApi.Entities.Product>();
            var productef = await context.Products.ToListAsync();

            foreach (var item in productef)
            {
                list.Add(new Entities.Product
                {
                    Name = item.Name,
                    ProductElaborationDate = item.ProductElaborationDate,
                    Price = item.Price,
                    ProductExpirationDate = item.ProductExpirationDate,
                    Description = item.Description,
                    Stock = item.Stock,
                    
                });



            }



            return list;

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupermarketApi.Entities.Product>> Get([FromRoute] int id)

        {
            var product = new SupermarketApi.Entities.Product();
            var productef = await context.Products.FirstOrDefaultAsync(f => f.Id == id);
            product = new Entities.Product
            {
                Name= productef.Name,
                Price = productef.Price,
                ProductElaborationDate= productef.ProductElaborationDate,
                ProductExpirationDate= productef.ProductExpirationDate, 
                Stock = productef.Stock,
                Description = productef.Description,
                

            };

            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            try
            {
                var productbd = ProductMap(product);
                context.Products.Add(productbd);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool ProductsExists(int id)
        {
            return context.Products.Any(e => e.Id == id);
        }
        private  Product ProductMap(Product products)
        {
            return new Product
                {
                Name = products.Name,
                Price=products.Price,
                ProductElaborationDate = products.ProductElaborationDate,
                ProductExpirationDate = products.ProductExpirationDate, 
                Stock=products.Stock,   
                Description=products.Description,
            
            };
        }
    }
}

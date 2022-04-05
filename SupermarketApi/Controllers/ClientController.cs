using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupermarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly SuperMarketTecocContext context;
        public ClientController(SuperMarketTecocContext context)
        {
            this.context = context;
        }  
        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupermarketApi.Entities.Client>>> Get()
        {
            var list = new List<SupermarketApi.Entities.Client>();
            var Clientef = await context.Clients.ToListAsync();

            foreach (var item in Clientef)
            {
                list.Add(new Entities.Client
                {
                    Name = item.Name,
                    Address = item.Address, 
                    CellPhoneNumber = item.CellPhoneNumber, 


                });



            }



            return list;

        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupermarketApi.Entities.Client>> Get([FromRoute] int id)

        {
            var client = new SupermarketApi.Entities.Client();
            var clientef = await context.Clients.FirstOrDefaultAsync(f => f.Id == id);
            client = new Entities.Client
            {
               Name=clientef.Name,  
               Address=clientef.Address,        
               CellPhoneNumber=clientef.CellPhoneNumber,  



            };

            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public ActionResult Post([FromBody] Client client)
        {
            try
            {
                var Clientbd = ClientMap(client);
                context.Clients.Add(Clientbd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            context.Entry(client).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            context.Clients.Remove(client);
            await context.SaveChangesAsync();

            return NoContent();
        }
        private bool ClientExists(int id)
        {
            return context.Clients.Any(e => e.Id == id);
        }
        private Client ClientMap(Client Client) 
        { 
        
            return new Client
            {
                Name = Client.Name, 
                Address = Client.Address,          
                CellPhoneNumber = Client.CellPhoneNumber,   

            };
        }
    }
}

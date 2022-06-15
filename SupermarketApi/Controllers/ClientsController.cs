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
    public class ClientsController : ControllerBase
    {
        private readonly SuperMarketTecocContext _context;

        public ClientsController(SuperMarketTecocContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public ActionResult GetClients()
        {
            try
            {
                return Ok(_context.Clients.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "GetClients")]
        public ActionResult GetClient(int id)
     
        {
            try
            {
                var client = _context.Clients.FirstOrDefault(c => c.Id == id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, [FromBody] Client client)
        {
            try
            {

                if (client.Id == id)
                {
                    _context.Entry(client).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetClients", new { id = client.Id }, client);
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostClient([FromBody] Client client)

        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return CreatedAtAction("GetClients", new { id = client.Id }, client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            try
            {
                var client= _context.Clients.FirstOrDefault(c => c.Id == id);
                if (client != null)
                {
                    _context.Clients.Remove(client);
                    _context.SaveChanges();
                    return Ok(id);
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

    }
}

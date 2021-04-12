using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBCRUDClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBCRUDClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listClients = await _context.CRUDClientDDBB.ToListAsync();
                return Ok(listClients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientsModel clients)
        {
            try
            {
                _context.Add(clients);
                await _context.SaveChangesAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClientsModel clients)
        {
            try
            {
                if(id != clients.Id)
                {
                    return NotFound();
                }

                _context.Update(clients);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El Cliente fue actualizado con éxito." });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clients = await _context.CRUDClientDDBB.FindAsync(id);
                if (clients == null)
                {
                    return NotFound();
                }

                _context.CRUDClientDDBB.Remove(clients);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El Cliente fue eliminado con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

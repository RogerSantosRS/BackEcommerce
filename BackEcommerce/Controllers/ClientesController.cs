using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEcommerce.Models;

namespace BackEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly bdecomerceContext _context;

        public ClientesController()
        {
            _context = new bdecomerceContext();
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
          //if (_context.Clientes == null)
          //{
          //    return NotFound();
          //}
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
          //if (_context.Clientes == null)
          //{
          //    return NotFound();
          //}
          var cliente = await _context.Clientes.FindAsync(id);

          //  if (cliente == null)
          //  {
          //      return NotFound();
          //  }

            return cliente; 
        }

        // PUT: api/Clientes/5
      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            var clientefind = await _context.Clientes.FindAsync(id);
            if (id != clientefind.Id)
            {
                return BadRequest();
            }
            
            clientefind!.Nombre = cliente.Nombre;
            clientefind!.Apellidos = cliente.Apellidos;
            clientefind.Correo = cliente.Correo;
            clientefind.Telefono = cliente.Telefono;
            
            _context.Entry(clientefind).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Clientes
        
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
          if (_context.Clientes == null)
          {
              return BadRequest("Entity set 'bdecomerceContext.Clientes'  is null.");
          }
            cliente.Estatus = "a";
            cliente.FechaCreate = DateTime.Now;
            _context.Clientes.Add(cliente);
            if (cliente.Nombre ==""|| cliente.Telefono ==""|| cliente.Correo ==""|| cliente.Apellidos =="") 
            {
                return Problem("Entity set 'bdecomerceContext.Clientes'  is null.");
            }
            else
            {
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var clientedelete = await _context.Clientes.FindAsync(id);
            if (id != clientedelete.Id)
            {
                return BadRequest();
            }

            clientedelete.Estatus = "b";
            clientedelete.FechaDelete = DateTime.Now;

            _context.Entry(clientedelete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }
    

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

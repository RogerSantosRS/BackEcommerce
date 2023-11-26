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
    public class PerfilesController : ControllerBase
    {
        private readonly bdecomerceContext _context;

        public PerfilesController()
        {
            _context = new bdecomerceContext();
        }

        // GET: api/Perfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfils()
        {
          //if (_context.Perfils == null)
          //{
          //    return NotFound();
          //}
            return await _context.Perfils.Where(x=>x.FechaDelete==null).ToListAsync();
        }

        // GET: api/Perfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
          //if (_context.Perfils == null)
          //{
          //    return NotFound();
          //}
            var perfil = await _context.Perfils.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // PUT: api/Perfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, Perfil perfil)
        {
            var perfilfind = await _context.Perfils.FindAsync(id);
            if (id != perfilfind.Id)
            {
                return BadRequest();
            }

            perfilfind.Nombre = perfil.Nombre;

            _context.Entry(perfilfind).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
            if (_context.Clientes == null)
            {
                return BadRequest("Entity set 'bdecomerceContext.Clientes'  is null.");
            }
            perfil.Estatus = "a";
            perfil.FechaCreate = DateTime.Now;
            _context.Perfils.Add(perfil);

            if (string.IsNullOrEmpty(perfil.Nombre))
            {
                return Problem("Entity set 'bdecomerceContext.Clientes'  is null.");
            }
            else
            {
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetPerfil", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfildelete = await _context.Perfils.FindAsync(id);
            if (id != perfildelete.Id)
            {
                return BadRequest();
            }

            perfildelete.Estatus = "b";
            perfildelete.FechaDelete = DateTime.Now;

            _context.Entry(perfildelete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        private bool PerfilExists(int id)
        {
            return (_context.Perfils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

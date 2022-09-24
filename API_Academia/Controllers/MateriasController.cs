using API_Academia.Context;
using API_Academia.Dtos;
using API_Academia.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Academia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MateriasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<List<MateriasDtos>> GetMaterias()
        {
            var materias = await _context.Materias.ToListAsync();
            return _mapper.Map<List<MateriasDtos>>(materias);
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateria(int id)
        {
            var materias = await _context.Materias.FirstOrDefaultAsync(x => x.Materia_Id == id);
            var result = _mapper.Map<Materias, MateriasDtos>(materias);
            return Ok(result);
        }



        // POST: api/Materias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Materias>> PostMaterias(Materias materias)
        {
            _context.Materias.Add(materias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterias", new { id = materias.Materia_Id }, materias);
        }

      


        // PUT: api/Materias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materias materias)
        {
            if (id != materias.Materia_Id)
            {
                return BadRequest();
            }

            _context.Entry(materias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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
        private bool UsersExists(int id)
        {
            return _context.Materias.Any(e => e.Materia_Id == id);
        }

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materias>> DeleteMateria(int id)
        {
            var materias = await _context.Materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(materias);
            await _context.SaveChangesAsync();

            return materias;
        }
    }
}

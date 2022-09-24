using API_Academia.Context;
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
    public class EstudianteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EstudianteController(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        [HttpGet]
        public async Task<List<EstudianteDtos>> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiante.ToListAsync();
            return _mapper.Map<List<EstudianteDtos>>(estudiantes);
        }


        // GET: api/Estudiante/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthors(int id)
        {
            var estudiantes = await _context.Estudiante.FirstOrDefaultAsync(x => x.Estudiante_Id == id);
            var result = _mapper.Map<Estudiante, EstudianteDtos>(estudiantes);
            return Ok(result);
        }

        // GET: api/Estudiante
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        //{
        //    return await _context.Estudiante.ToListAsync();
        //}

        // POST: api/Estudiante
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiantes(Estudiante estudiante)
        {
            _context.Estudiante.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiantes", new { id = estudiante.Estudiante_Id }, estudiante);
        }


        /*
        // GET: api/Estudiante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiantes = await _context.Estudiante.FindAsync(id);

            if (estudiantes == null)
            {
                return NotFound();
            }

            return estudiantes;
        }
        */

       


        // PUT: api/Estudiante/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.Estudiante_Id)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

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
            return _context.Estudiante.Any(e => e.Estudiante_Id == id);
        }

        // DELETE: api/Estudiante/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estudiante>> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiante.Remove(estudiante);
            await _context.SaveChangesAsync();

            return estudiante;
        }


    }
}

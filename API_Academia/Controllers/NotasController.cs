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
    public class NotasController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public NotasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Notas
        [HttpGet]
        public async Task<List<NotasDtos>> GetNotas()
        {
            var notas = await _context.Notas.ToListAsync();
            return _mapper.Map<List<NotasDtos>>(notas);
        }

        // GET: api/Notas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNota(int id)
        {
            var Notas = await _context.Notas.FirstOrDefaultAsync(x => x.Materia_Id == id);
            var result = _mapper.Map<Notas, NotasDtos>(Notas);
            return Ok(result);
        }


        // POST: api/Notas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notas>> PostNotas(Notas notas)
        {
            _context.Notas.Add(notas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotas", new { id = notas.Nota_Id }, notas);
        }




        // PUT: api/Notas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNota(int id, Notas notas)
        {
            if (id != notas.Nota_Id)
            {
                return BadRequest();
            }

            _context.Entry(notas).State = EntityState.Modified;

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
            return _context.Notas.Any(e => e.Nota_Id == id);
        }


    }
}

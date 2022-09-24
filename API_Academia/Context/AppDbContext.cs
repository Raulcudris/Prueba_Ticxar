using API_Academia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Academia.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        {

        }

        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }

    }
}

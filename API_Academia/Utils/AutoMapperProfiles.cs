using API_Academia.Dtos;
using API_Academia.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Academia.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Estudiante, EstudianteDtos>().ReverseMap();
            CreateMap<EstudianteDtos, Estudiante>();

            CreateMap<Profesor, ProfesorDtos>().ReverseMap();
            CreateMap<ProfesorDtos, Profesor>();

            CreateMap<Materias, MateriasDtos>().ReverseMap();
            CreateMap<MateriasDtos, Materias>();

            CreateMap<Notas, NotasDtos>().ReverseMap();
            CreateMap<NotasDtos, Notas>();

        }
    }
}

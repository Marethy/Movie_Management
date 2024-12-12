using AutoMapper;
using WebApplication1.Models.Entities;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}

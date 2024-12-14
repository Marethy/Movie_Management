using AutoMapper;
using WebApplication1.Models.Entities;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Genre mapping
            CreateMap<Genre, GenreDTO>().ReverseMap();

            // Movie mapping
            CreateMap<Movie, MovieDTO>().ReverseMap();

            // MovieGenre mapping
            CreateMap<MovieGenre, MovieGenreDTO>().ReverseMap();

            // Order mapping
            CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets))
            .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets))
                .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts));

            // OrderProduct mapping
            CreateMap<OrderProduct, OrderProductDTO>().ReverseMap();

            // Product mapping
            CreateMap<Product, ProductDTO>().ReverseMap();

            // Room mapping
            CreateMap<Room, RoomDTO>()
       .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            CreateMap<RoomDTO, Room>()
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

            // Seat mapping
            CreateMap<Seat, SeatDTO>().ReverseMap();

            // ShowTime mapping
            CreateMap<ShowTime, ShowTimeDTO>().ReverseMap();

            // Theater mapping
            CreateMap<Theater, TheaterDTO>().ReverseMap();

            // Ticket mapping
            CreateMap<Ticket, TicketDTO>().ReverseMap();

            // User mapping
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

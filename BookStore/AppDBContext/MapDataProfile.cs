using AutoMapper;
using BookStore.Core.DTO;
using BookStore.Core.Entities;

namespace BookStore.BLL.AppDBContext
{
    public class MapDataProfile : Profile
    {
        public MapDataProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}

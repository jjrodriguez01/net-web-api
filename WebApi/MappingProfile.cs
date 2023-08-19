using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<AuthorDto, Author>().ConstructUsing(x => new Author(x.FullName, x.BirthCity, x.DateOfBirth ?? DateTime.Now)).ReverseMap();
            CreateMap<CreateBookDto, Book>().ConstructUsing(x => new Book(x.Title, x.Year, x.Genre, x.Pages, x.AuthorId));
            CreateMap<Book, BookDto>().ForMember(dest => dest.AuthorName,
                opt => opt.MapFrom(src => src.Author.FullName));
        }
    }
}

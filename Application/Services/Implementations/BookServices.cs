using Application.Dto;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public BookServices(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        async Task IBookServices.AddBookAsync(Book book)
        {
            var created = repository.Add(book);
            await repository.UnitOfWork.SaveEntitiesAsync();
        }

        Task<int> IBookServices.CountBooks()
        {
            var count = repository.Count();
            return Task.FromResult(count);
        }

        async Task<List<BookDto>> IBookServices.GetAllBooks()
        {
            var books = await repository.GetAll();
            return mapper.Map<List<BookDto>>(books);
        }
    }
}

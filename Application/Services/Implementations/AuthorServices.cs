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
    public class AuthorServices : IAuthorServices
    {
        private readonly IAuthorRepository repository;
        private readonly IMapper mapper;

        public AuthorServices(IAuthorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        async Task IAuthorServices.AddAuthorAsync(Author author)
        {
            var created = repository.Add(author);
            await repository.UnitOfWork.SaveEntitiesAsync();
        }

        async Task<List<AuthorDto>> IAuthorServices.GetAllAuthors()
        {
            var authors = await repository.GetAll();
            return mapper.Map<List<AuthorDto>>(authors);
        }
    }
}

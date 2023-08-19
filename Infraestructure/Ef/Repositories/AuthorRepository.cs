using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infraestructure.Ef.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Ef.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MyDbContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public AuthorRepository(MyDbContext context)
        {
            _context = context;
        }

        public Author Add(Author author)
        {
            return _context.Add(author).Entity;
        }

        public Task<List<Author>> GetAll()
        {
            var authors = _context.Authors.AsNoTracking().ToListAsync();
            return authors;
        }
    }
}

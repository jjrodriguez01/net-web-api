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
    public class BookRepository : IBookRepository
    {
        private readonly MyDbContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BookRepository(MyDbContext context)
        {
            _context = context;
        }

        public Book Add(Book book)
        {
            return _context.Add(book).Entity;
        }

        Task<List<Book>> IBookRepository.GetAll()
        {
            var books = _context.Books.Include(x => x.Author).AsNoTracking().ToListAsync();//incluir autor por eager load
            return books;
        }

        int IBookRepository.Count()
        {
            var count = _context.Books.Count();
            return count;
        }
    }
}

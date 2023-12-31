﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Add(Book book);
        Task<List<Book>> GetAll();
        int Count();
    }
}

using Application.Dto;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices bookServices;
        private readonly IMapper mapper;

        public BooksController(IBookServices bookServices, IMapper mapper)
        {
            this.bookServices = bookServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            var books = await bookServices.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto dto)
        {
            //validar maximo # de libros
            var count = await bookServices.CountBooks();
            if(count >= 3)
            {
                return UnprocessableEntity("No es posible registrar el libro, se alcanzó el máximo permitido.");
            }
            var book = mapper.Map<Book>(dto);
            await bookServices.AddBookAsync(book);
            return Ok();//preferible retornar 201 created, por la prueba y tiempo dejo asi :)
        }
    }
}

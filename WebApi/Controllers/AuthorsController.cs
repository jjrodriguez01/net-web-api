using Application.Dto;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorServices authorServices;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorServices authorServices, IMapper mapper)
        {
            this.authorServices = authorServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetUsers()
        {
            var users = await authorServices.GetAllAuthors();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorDto dto)
        {
            var author = mapper.Map<Author>(dto);
            await authorServices.AddAuthorAsync(author);
            return Ok(author);//preferible retornar 201 created, por la prueba y tiempo dejo asi :)
        }
    }
}

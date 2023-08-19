using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public string? Genre { get; set; }
        public int Pages { get; set; }
        public string? AuthorName { get; set; }
    }

    public class CreateBookDto
    {
        [Required(ErrorMessage = "El Title es obligatorio.")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres.")]
        public string? Title { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Year must be greater than 0.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "El Genre es obligatorio.")]
        [StringLength(60, ErrorMessage = "M[aximo 60 caracteres.")]
        public string? Genre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Pages must be greater than 0.")]
        public int Pages { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "AuthorId must be greater than 0.")]
        public int AuthorId { get; set; }
    }

}

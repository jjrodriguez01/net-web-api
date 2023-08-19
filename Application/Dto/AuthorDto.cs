using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    //prefiero tener un dto para presentar y uno para crear/actualizar pero este es sencillo
    public class AuthorDto
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(60, ErrorMessage = "M[aximo 60 caracteres.")]
        //[RegularExpression(@"^\S+$", ErrorMessage = "El nombre no puede ser vacio")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "BirthCity es obligatorio.")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres.")]
        public string? BirthCity { get; set; }

        [Required(ErrorMessage = "DateOfBirth obligatorio.")]
        public DateTime? DateOfBirth { get; set; }
    }
}

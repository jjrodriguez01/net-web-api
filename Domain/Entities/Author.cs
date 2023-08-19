using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Author")]
    public class Author
    {
        public int AuthorId { get; set; }
        public string? FullName { get; set; }
        public string? BirthCity { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Book>? Books { get; set; }

        internal Author() { }//para ef

        public Author(string fullName, string birthCity, DateTime dateOfBirth)//asegura creacion obj autor
        {
            FullName = fullName;
            BirthCity = birthCity;
            DateOfBirth = dateOfBirth;
        }
    }
}

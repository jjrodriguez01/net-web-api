using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Book")]
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public string? Genre { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        internal Book() { }//para ef

        public Book(string title, int year, string genre, int pages, int authorId)
        {
            Title = title;
            Year = year;
            Genre = genre;
            Pages = pages;
            AuthorId = authorId;
        }
    }
}

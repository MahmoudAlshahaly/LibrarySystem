using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BookDTO
{
    public class BookUpdateDTO
    {
        public int BookID { get; set; }
        [Required]
        public string BookISBN { get; set; }
        [Required]
        public string? BookTitle { get; set; }
        [Required]
        public string? BookDescription { get; set; }
        [Required]
        public string? BookAuthor { get; set; }
        public BookStatus BookStatus { get; set; } = BookStatus.Available;

    }
}

using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BookDTO
{
    public class BookReadDTO
    {
        public int BookID { get; set; }
        public string BookISBN { get; set; }
        public string? BookTitle { get; set; }
        public string? BookDescription { get; set; }
        public string? BookAuthor { get; set; }
        public BookStatus BookStatus { get; set; } 
    }
}

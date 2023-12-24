using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BookDTO
{
    public class BookWriteDTO
    {
        [Required]
        [MaxLength(20,ErrorMessage ="Max Length 20 character")]
        public string? BookISBN { get; set; }
        [Required]
        public string? BookTitle { get; set; }
        [Required]
        public string? BookDescription { get; set; }
        [Required]
        public string? BookAuthor { get; set; }
        public BookStatus BookStatus { get; set; } = BookStatus.Available;
        public bool isDeleted { get; set; }=false;

    }
}

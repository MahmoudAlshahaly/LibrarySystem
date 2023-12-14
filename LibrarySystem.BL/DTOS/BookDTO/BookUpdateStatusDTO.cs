using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BookDTO
{
    public class BookUpdateStatusDTO
    {
        public int BookID { get; set; }
        public BookStatus BookStatus { get; set; }
    }
}

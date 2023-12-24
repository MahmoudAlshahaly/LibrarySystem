using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.DAL.Enums;
using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BorrowBookDTO
{
    public class ReturnBorrowBookDto
    {
        public BookUpdateStatusDTO Book { get; set; }
        public int BorrowID { get; set; }
        public BorrowStatus BorrowStatus { get; set; } = BorrowStatus.Returned;

    }
}

using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BorrowBookDTO
{
    public class BorrowBookReadDTO
    {
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public BorrowStatus BorrowStatus { get; set; } = BorrowStatus.Borrowing;
        public BookReadDTO Book { get; set; }
        public int UserID { get; set; }
    }
}

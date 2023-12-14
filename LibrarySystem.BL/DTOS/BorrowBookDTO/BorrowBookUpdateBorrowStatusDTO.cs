using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BorrowBookDTO
{
    public class BorrowBookUpdateBorrowStatusDTO
    {
        public int BorrowID { get; set; }
        public BorrowStatus BorrowStatus { get; set; } = BorrowStatus.Returned;
    }
}

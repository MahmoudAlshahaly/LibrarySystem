using LibrarySystem.DAL.Enums;
using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.BorrowBookDTO
{
    public class BorrowBookReadForUserDTO
    {            
        public int BorrowID { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public BorrowStatus BorrowStatus { get; set; }
    }
}

using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Models
{
    public class BorrowBook:BaseEntity
    {
        public int BorrowID { get; set; }
        public DateTime BorrowDate { get; set; }
        public BorrowStatus BorrowStatus { get; set; }
        public int BookID { get; set; }
        public string? BookTitle { get; set; }
        public int UserID { get; set; }
    }
}

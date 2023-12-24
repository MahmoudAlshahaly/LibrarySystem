using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.IRepositories
{
    public interface IBorrowBookRepository
    {
        List<BorrowBook> GetAllForUser(int UserID);
        int ReturnBorrow(BorrowBook Entity);

        int BorrowingBook(BorrowBook Entity);
        int UpdateStatus(BorrowBook Entity);
    }
}

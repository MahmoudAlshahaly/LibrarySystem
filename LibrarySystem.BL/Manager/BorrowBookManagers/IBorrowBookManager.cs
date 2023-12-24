using LibrarySystem.BL.DTOS.BorrowBookDTO;
using LibrarySystem.BL.DTOS.UserDTO;
using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Manager.BorrowBookManagers
{
    public interface IBorrowBookManager
    {
        IEnumerable<BorrowBookReadForUserDTO> GetAllForUser(int UserID);
        ReturnBorrowBookDto ReturnBook(ReturnBorrowBookDto entity);
        BorrowBookWriteDTO BorrowingBook(BorrowBookWriteDTO entity);
        int UpdateStatus(BorrowBookUpdateBorrowStatusDTO entity);
        

    }
}

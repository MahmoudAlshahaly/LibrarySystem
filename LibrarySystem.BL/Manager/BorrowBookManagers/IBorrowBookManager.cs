using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.BorrowBookDTO;
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
        BorrowBookWriteDTO Insert(BorrowBookWriteDTO entity);
        int UpdateStatus(BorrowBookUpdateBorrowStatusDTO entity);
        

    }
}

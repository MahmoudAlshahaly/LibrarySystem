using LibrarySystem.BL.DTOS.BookDTO;

namespace LibrarySystem.BL.Manager.BookManagers
{
    public interface IBookManager
    {
        IEnumerable<BookReadDTO> GetAll();
        BookUpdateDTO GetById(int id);
        IEnumerable<BookReadDTO> GetByAuthorOrTitleOrISBN(string pattern);
        BookWriteDTO Insert(BookWriteDTO entity);
        BookUpdateDTO Update(BookUpdateDTO entity);
        int Delete(int ID);
        int UpdateStatus(BookUpdateStatusDTO entity);
    }
}

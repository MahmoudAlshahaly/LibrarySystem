using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.IRepositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int ID);
        List<Book> GetByAuthorOrTitleOrISBN(string pattern);
        int Insert(Book Entity);
        int DeleteByID(int ID);
        int DeleteAll();
        int Update(Book Entity);
        int UpdateStatus(Book Entity);
    }
}

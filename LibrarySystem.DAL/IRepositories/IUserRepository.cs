using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int ID);
        User GetByNamePassword(string Name, string Password);
        int Insert(User Entity);
        int DeleteByID(int ID);
        int Update(User Entity);
    }
}

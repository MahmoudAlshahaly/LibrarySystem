using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Manager.UserManagers
{
    public interface IUserManager
    {
        IEnumerable<UserReadDTO> GetAll();
        UserReadDTO GetById(int id);
        UserReadDTO Login(string UserName ,string Password);
        UserWriteDTO Insert(UserWriteDTO entity);
        UserUpdateDTO Update(UserUpdateDTO entity);
        int Delete(int ID);
    }
}

using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.UserDTO
{
    public class UserReadDTO
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public UserType UserType { get; set; }

    }
}

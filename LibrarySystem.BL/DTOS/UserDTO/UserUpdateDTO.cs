using LibrarySystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.DTOS.UserDTO
{
    public class UserUpdateDTO
    {
        public int UserID { get; set; }
        [Required]
        [StringLength(maximumLength:15,ErrorMessage ="User Name Length Must Be Between 5 and 15 character",MinimumLength =5)]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? UserPassword { get; set; }
        public UserType UserType { get; set; }

    }
}

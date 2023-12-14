using AutoMapper;
using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.BorrowBookDTO;
using LibrarySystem.BL.DTOS.UserDTO;
using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Book, BookReadDTO>().ReverseMap();
            CreateMap<Book, BookUpdateDTO>().ReverseMap();
            CreateMap<Book, BookWriteDTO>().ReverseMap();
            CreateMap<Book, BookUpdateStatusDTO>().ReverseMap();

            CreateMap<User, UserReadDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<User, UserWriteDTO>().ReverseMap();

            CreateMap<BorrowBook, BorrowBookWriteDTO>().ReverseMap();
            CreateMap<BorrowBook, BorrowBookReadForUserDTO>().ReverseMap();
            CreateMap<BorrowBook, BorrowBookUpdateBorrowStatusDTO>().ReverseMap();
           

        }
    }
}

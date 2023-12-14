using AutoMapper;
using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.BorrowBookDTO;
using LibrarySystem.DAL.IRepositories;
using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Manager.BorrowBookManagers
{
    public class BorrowBookManager : IBorrowBookManager
    {
        private readonly IBorrowBookRepository borrowBookRepository;
        private readonly IMapper mapper;

        public BorrowBookManager(IBorrowBookRepository borrowBookRepository,IMapper mapper )
        {
            this.borrowBookRepository = borrowBookRepository;
            this.mapper = mapper;
        }

        public IEnumerable<BorrowBookReadForUserDTO> GetAllForUser(int UserID)
        {
            var borrowBooks = borrowBookRepository.GetAllForUser(UserID);

            if (borrowBooks == null)
            {
                return null;
            }
            var result = mapper.Map<List<BorrowBookReadForUserDTO>>(borrowBooks);

            return result;
        }

        public BorrowBookWriteDTO Insert(BorrowBookWriteDTO entity)
        {
            var result = mapper.Map<BorrowBook>(entity);
            borrowBookRepository.Insert(result);
            return entity;
        }

        public int UpdateStatus(BorrowBookUpdateBorrowStatusDTO entity)
        {

            var result = mapper.Map<BorrowBook>(entity);
            return borrowBookRepository.UpdateStatus(result);
        }
    }
}

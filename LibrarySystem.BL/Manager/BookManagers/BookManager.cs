using AutoMapper;
using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.DAL.IRepositories;
using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySystem.BL.Manager.BookManagers
{
    internal class BookManager : IBookManager
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookManager(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }
        public IEnumerable<BookReadDTO> GetAll()
        {

            var books =   bookRepository.GetAll();
            
            if (books == null)
            {
                return null;
            }
            var result = mapper.Map<List<BookReadDTO>>(books);
          
            return result;
        }

        public BookUpdateDTO GetById(int id)
        {
            var book=   bookRepository.GetById(id);
            var result = mapper.Map<BookUpdateDTO>(book);
            return result;
        }

        public IEnumerable<BookReadDTO> GetByAuthorOrTitleOrISBN(string pattern)
        {
            var books = bookRepository.GetByAuthorOrTitleOrISBN(pattern);

            if (books == null)
            {
                return null;
            }
            var result = mapper.Map<List<BookReadDTO>>(books);

            return result;
        }

        public BookWriteDTO Insert(BookWriteDTO entity)
        {
            var result = mapper.Map<Book>(entity);
            bookRepository.Insert(result);
            return entity;
        }

        public BookUpdateDTO Update(BookUpdateDTO entity)
        {
            var result = mapper.Map<Book>(entity);
            bookRepository.Update(result);
            return entity;
        }
        public int Delete(int ID)
        {
            return bookRepository.DeleteByID(ID);
        }
        public int UpdateStatus(BookUpdateStatusDTO entity)
        {
           var result = mapper.Map<Book>(entity);
           return bookRepository.UpdateStatus(result);

        }
    }
}

using AutoMapper;
using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.UserDTO;
using LibrarySystem.DAL.IRepositories;
using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Manager.UserManagers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserManager(IUserRepository userRepository,IMapper mapper)
        {

            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public IEnumerable<UserReadDTO> GetAll()
        {
            var books = userRepository.GetAll();

            if (books == null)
            {
                return null;
            }
            var result = mapper.Map<List<UserReadDTO>>(books);

            return result;
        }
        public UserReadDTO GetById(int id)
        {
           var user = userRepository.GetById(id);
            var result = mapper.Map<UserReadDTO>(user);
            return result;
        }
        public UserWriteDTO Insert(UserWriteDTO entity)
        {

            var result = mapper.Map<User>(entity);
            userRepository.Insert(result);
            return entity;
        }
        public UserUpdateDTO Update(UserUpdateDTO entity)
        {
            var result = mapper.Map<User>(entity);
            userRepository.Update(result);
            return entity;
        }
        public int Delete(int ID)
        {
            return userRepository.DeleteByID(ID);
        }

        public UserReadDTO Login(string UserName, string Password)
        {
            var user = userRepository.GetByNamePassword(UserName,Password);
            var result = mapper.Map<UserReadDTO>(user);
            return result;
        }
    }
}

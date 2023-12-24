using DAL;
using LibrarySystem.DAL.Enums;
using LibrarySystem.DAL.IRepositories;
using LibrarySystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataTable dataTable;
        private readonly DBHelper db;
        Dictionary<string, object> param;
        public UserRepository(DBHelper db)
        {
            dataTable = new DataTable();
            this.db = db;
        }

        public List<User> GetAll()
        {
            dataTable = db.SelectStoredNoParam("UserGetAll");
            List<User> entitys = MapDataTableToUsers(dataTable);
            return entitys;
        }

        public User GetById(int id)
        {
            param = new Dictionary<string, object>()
            {
                ["@UserID"] = id,
            };
            dataTable = db.SelectStored("UserByID", param);
            User entity = MapDataRowToUser(dataTable.Rows[0]);
            return entity;
        }
        public int Insert(User entity)
        {
            param = new Dictionary<string, object>()
            {
                //["@UserID"] = entity.UserID,
                ["@UserName"] = entity.UserName,
                ["@UserPassword"] = entity.UserPassword,
                ["@UserType"] = entity.UserType
            };
            return db.ExecuteStored("UserInsert", param);

        }
        public int Update(User entity)
        {
            param = new Dictionary<string, object>()
            {
                ["@UserID"] = entity.UserID,
                ["@UserName"] = entity.UserName,
                ["@UserPassword"] = entity.UserPassword,
                ["@UserType"] = entity.UserType
            };
            return db.ExecuteStored("UserUpdate", param);
        }
        public int DeleteByID(int id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                ["@UserID"] = id

            };
            return db.ExecuteStored("UserDeleteByID", param);
        }

        public User GetByNamePassword(string Name, string Password)
        {
            param = new Dictionary<string, object>()
            {
                ["@UserName"] = Name,
                ["@UserPassword"] = Password,
            };
            dataTable = db.SelectStored("UserByNameAndPassword", param);
            if(dataTable.Rows.Count==0) return null;
            User entity = MapDataRowToUser(dataTable.Rows[0]);
            return entity;
        }
        public List<User> MapDataTableToUsers(DataTable dataTable)
        {
            List<User> entitys = new List<User>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entitys.Add(MapDataRowToUser(dataRow));
            }
            return entitys;
        }
        public User MapDataRowToUser(DataRow dataRow)
        {
            User entity = new User();

            try
            {
                entity.UserID = Convert.ToInt32(dataRow[0]);
                entity.UserName = dataRow[1].ToString();
                entity.UserPassword = dataRow[2].ToString();
                entity.UserType = (UserType)dataRow[3];

            }
            catch (Exception) { }
            return entity;
        }

    }
}

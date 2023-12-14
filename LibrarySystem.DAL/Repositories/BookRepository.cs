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
using System.Xml.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private DataTable dataTable;
        private readonly DBHelper db;
        Dictionary<string, object> param;
        public BookRepository(DBHelper db)
        {
            dataTable = new DataTable();
            this.db = db;
        }
        //public DataTable GetAll()
        //{
        //    return dataTable = db.SelectAllStored("BookGetAll");
        //}
        public List<Book> GetAll()
        {
            dataTable = db.SelectAllStored("BookGetAll");
            List<Book> entitys = MapDataTableToBooks(dataTable);
            return entitys;
        }

        public Book GetById(int id)
        {
            param = new Dictionary<string, object>()
            {
                ["@BookID"] = id,
            };
            dataTable = db.SelectStored("BookByID", param);
            Book entity = MapDataRowToBook(dataTable.Rows[0]);
            return entity;
        }
        public int Insert(Book entity)
        {
            param = new Dictionary<string, object>()
            {
                //["@BookID"] = entity.BookID,
                ["@BookISBN"] = entity.BookISBN,
                ["@BookTitle"] = entity.BookTitle,
                ["@BookAuthor"] = entity.BookAuthor,
                ["@BookDescription"] = entity.BookDescription,
                ["@BookStatus"] = entity.BookStatus
            };
            return db.ExecuteStored("BookInsert", param);

        }
        public int Update(Book entity)
        {
            param = new Dictionary<string, object>()
            {
                ["@BookID"] = entity.BookID,
                ["@BookISBN"] = entity.BookISBN,
                ["@BookTitle"] = entity.BookTitle,
                ["@BookAuthor"] = entity.BookAuthor,
                ["@BookDescription"] = entity.BookDescription,
                ["@BookStatus"] = entity.BookStatus
            };
            return db.ExecuteStored("BookUpdate", param);
        }
        public int DeleteByID(int id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                ["@BookID"] =id

            };
            return db.ExecuteStored("BookDeleteByID", param);
        }
        public int DeleteAll()
        {
            return db.ExecuteStored("BookDeleteAll", null);
        }
        public List<Book> GetByAuthorOrTitleOrISBN(string pattern)
        {
            param = new Dictionary<string, object>()
            {
                ["@pattern"] = pattern,
            };
            dataTable = db.SelectStored("BookByAuthorOrTitleOrISBN", param);
            List< Book> entity = MapDataTableToBooks(dataTable);
            return entity;
        }

       

        public int UpdateStatus(Book entity)
        {
            param = new Dictionary<string, object>()
            {
                ["@BookID"] = entity.BookID,
                ["@BookStatus"] = entity.BookStatus
            };
            return db.ExecuteStored("BookUpdateStatus", param);
        }
        public List<Book> MapDataTableToBooks(DataTable dataTable)
        {
            List<Book> entitys = new List<Book>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entitys.Add(MapDataRowToBook(dataRow));
            }
            return entitys;
        }
        public Book MapDataRowToBook(DataRow dataRow)
        {
            Book entity = new Book();
            entity.BookID = Convert.ToInt32(dataRow[0]);
            entity.BookISBN = dataRow[1].ToString();
            entity.BookTitle = dataRow[2].ToString();
            entity.BookAuthor = dataRow[3].ToString();
            entity.BookDescription = dataRow[4].ToString();
            entity.BookStatus =(BookStatus) dataRow[5];
            return entity;
        }
    }
}

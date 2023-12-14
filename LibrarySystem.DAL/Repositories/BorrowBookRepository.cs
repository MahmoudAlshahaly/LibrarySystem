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
    public class BorrowBookRepository : IBorrowBookRepository
    {
        private DataTable dataTable;
        private readonly DBHelper db;
        Dictionary<string, object> param;
        public BorrowBookRepository(DBHelper db)
        {
            dataTable = new DataTable();
            this.db = db;
        }

        public List<BorrowBook> GetAllForUser(int UserID)
        {
            param = new Dictionary<string, object>()
            {
                ["@UserID"] = UserID,
            };
            dataTable = db.SelectStored("BorrowBookGetAllForUser", param);
            List<BorrowBook> entity = MapDataTableToBorrowBooks(dataTable);
            return entity;
        }

        public int Insert(BorrowBook entity)
        {
            param = new Dictionary<string, object>()
            {
                //["@BorrowID"] = entity.BorrowID,
                ["@BookID"] = entity.BookID,
                ["@UserID"] = entity.UserID,
                ["@BorrowDate"] = entity.BorrowDate,
                ["@BorrowStatus"] = entity.BorrowStatus
            };
            return db.ExecuteStored("BorrowBookInsert", param);
        }

        public int UpdateStatus(BorrowBook entity)
        {
            param = new Dictionary<string, object>()
            {
                ["@BorrowID"] = entity.BorrowID,
                ["@BorrowStatus"] = entity.BorrowStatus
            };
            return db.ExecuteStored("BorrowBookUpdateStatus", param);
        }
        public List<BorrowBook> MapDataTableToBorrowBooks(DataTable dataTable)
        {
            List<BorrowBook> entitys = new List<BorrowBook>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entitys.Add(MapDataRowToBorrowBook(dataRow));
            }
            return entitys;
        }
        public BorrowBook MapDataRowToBorrowBook(DataRow dataRow)
        {
            BorrowBook entity = new BorrowBook();
            entity.BorrowID = Convert.ToInt32(dataRow[0]);
            entity.BorrowDate = Convert.ToDateTime(dataRow[1]);
            entity.BorrowStatus = (BorrowStatus)dataRow[2];
            entity.BookID = Convert.ToInt32(dataRow[3]);
            entity.BookTitle = dataRow[4].ToString();
            entity.UserID = Convert.ToInt32(dataRow[5]);
            return entity;
        }
    }
}

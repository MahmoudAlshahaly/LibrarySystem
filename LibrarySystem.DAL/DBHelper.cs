using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        SqlConnection con;
        SqlCommand sqlcmd;
        SqlDataAdapter da;
        DataTable tbl;

        public DBHelper()
        {
            con = new SqlConnection("Server=.\\SQLEXPRESS;Database=LibrarySystem;integrated security=true");
            sqlcmd = new SqlCommand();
            sqlcmd.Connection = con;
            da = new SqlDataAdapter(sqlcmd);
            tbl = new DataTable();
        }
        public DataTable SelectAllStored(string cmd)
        {
            tbl.Reset();
            sqlcmd.CommandText = cmd;
            sqlcmd.Parameters.Clear();

            da.Fill(tbl);
            return tbl;
        }
        public DataTable SelectStored(string cmd, Dictionary<string, object> param)
        {
            tbl.Reset();
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Clear();

            if (param != null)
            {
                foreach (KeyValuePair<string, object> item in param)
                {
                    sqlcmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            da.Fill(tbl);
            return tbl;
        }

        public int ExecuteStored(string cmd, Dictionary<string, object> param)
        {
            //, SqlParameter[] param
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = cmd;
            sqlcmd.Parameters.Clear();
            //SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con);
            //sqlBulkCopy.DestinationTableName = "";
            //sqlBulkCopy.WriteToServer(DataTable);
            if (param != null)
            {
                //sqlcmd.Parameters.AddRange(param);
                foreach (KeyValuePair<string, object> item in param)
                {
                    sqlcmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            else
            {
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.Clear();
            }
            con.Open();
            int affected = sqlcmd.ExecuteNonQuery();
            con.Close();

            return affected;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ProjectName.My_Classes
{
    class DB_General : DB_Connection
    {
        public SqlCommand CMD;
        public DB_General()
        {
            CMD = new SqlCommand();
            CMD.Connection = conn;
        }

        //Insert, Update And Delete...
        public void general_query(string query)
        {
            Open_Connection();
            CMD.CommandText = query;
            CMD.ExecuteNonQuery();
            Close_Connection();

        }


        public DataTable MyTable(string query)
        {
            Open_Connection();
            CMD.CommandText = query;
            SqlDataAdapter myAdapter = new SqlDataAdapter(CMD);
            DataTable mytbl = new DataTable();
            myAdapter.Fill(mytbl);
            return mytbl;
        }
    }
}
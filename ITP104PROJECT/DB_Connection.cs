using System.Data;
using System.Data.SqlClient;

namespace ProjectName.My_Classes
{
    public class DB_Connection
    {
        protected SqlConnection conn;

        string con = "Server=localhost;Database=company;User=root;Password=091203";

        public DB_Connection()
        {
            conn = new SqlConnection(con);
        }

        protected void Open_Connection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        protected void Close_Connection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TesWeb1
{
    public class User
    {
        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Tel { get; set; }
        public string Gender { get; set; }
        public string NumAddress { get; set; }
        public string Tumbon { get; set; }
        public string Amphoe { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostNumber { get; set; }

       
        public User() { }

        public DataSet selectUser()
        {
            SqlCommand sql_com = new SqlCommand("uspGetUser", con);
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            con.Open();
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            con.Close();

            return dt;
        }
    }
}
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
        public string Tambon { get; set; }
        public string Amphoe { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostNumber { get; set; }
        public DateTime BirthDay {get; set;}

       
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

        public void addCustomer()
        {
            SqlCommand sql_com = new SqlCommand("uspAddUser", con);
            adapter.InsertCommand = sql_com;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.AddWithValue("@FirstName", FirstName);
            adapter.InsertCommand.Parameters.AddWithValue("@LastName", LastName);
            adapter.InsertCommand.Parameters.AddWithValue("@Email", Email);
            adapter.InsertCommand.Parameters.AddWithValue("@Tel", Tel);
            adapter.InsertCommand.Parameters.AddWithValue("@Username", Username);
            adapter.InsertCommand.Parameters.AddWithValue("@BirthDay", BirthDay);
            adapter.InsertCommand.Parameters.AddWithValue("@Gender", Gender);
            adapter.InsertCommand.Parameters.AddWithValue("@Tambon", Tambon);
            adapter.InsertCommand.Parameters.AddWithValue("@Amphoe", Amphoe);
            adapter.InsertCommand.Parameters.AddWithValue("@City", City);
            adapter.InsertCommand.Parameters.AddWithValue("@Country", Country);
            adapter.InsertCommand.Parameters.AddWithValue("@PostNumber", PostNumber);

            con.Open();
            adapter.InsertCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}
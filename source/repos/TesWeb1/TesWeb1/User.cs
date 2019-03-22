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

        public string UserID { get; set; }
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
        public string PostNumber { get; set; }
        public string BirthDay {get; set;}

       
        public User() { }
        public User(string userid) { }
        public User(string userid,string firstname, string lastname, string username, string tel, string email, string gen,string numaddress ,string tambon, string amphoe, string city, string country, string postnumber, string birthday) { }

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

                adapter.InsertCommand.Parameters.AddWithValue("@UserID", UserID);
                adapter.InsertCommand.Parameters.AddWithValue("@FirstName", FirstName);
                adapter.InsertCommand.Parameters.AddWithValue("@LastName", LastName);
                adapter.InsertCommand.Parameters.AddWithValue("@Email", Email);
                adapter.InsertCommand.Parameters.AddWithValue("@Tel", Tel);
                adapter.InsertCommand.Parameters.AddWithValue("@Username", Username);
                adapter.InsertCommand.Parameters.AddWithValue("@BrithDay", BirthDay);
                adapter.InsertCommand.Parameters.AddWithValue("@Gender", Gender);
                adapter.InsertCommand.Parameters.AddWithValue("@NumAddress", NumAddress);
                adapter.InsertCommand.Parameters.AddWithValue("@Tumbun", Tambon);
                adapter.InsertCommand.Parameters.AddWithValue("@Amphoe", Amphoe);
                adapter.InsertCommand.Parameters.AddWithValue("@City", City);
                adapter.InsertCommand.Parameters.AddWithValue("@Country", Country);
                adapter.InsertCommand.Parameters.AddWithValue("@PostNumber", PostNumber);

                con.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
        }        
        public void editCustomer()
        {
            SqlCommand sql_com = new SqlCommand("uspUpdateUser", con);
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@FirstName", FirstName);
            adapter.UpdateCommand.Parameters.AddWithValue("@FirstName", FirstName);
            adapter.UpdateCommand.Parameters.AddWithValue("@LastName", LastName);
            adapter.UpdateCommand.Parameters.AddWithValue("@Email", Email);
            adapter.UpdateCommand.Parameters.AddWithValue("@Tel", Tel);
            adapter.UpdateCommand.Parameters.AddWithValue("@Username", Username);
            adapter.UpdateCommand.Parameters.AddWithValue("@BirthDay", BirthDay);
            adapter.UpdateCommand.Parameters.AddWithValue("@Gender", Gender);
            adapter.UpdateCommand.Parameters.AddWithValue("@Tumbun", Tambon);
            adapter.UpdateCommand.Parameters.AddWithValue("@Amphoe", Amphoe);
            adapter.UpdateCommand.Parameters.AddWithValue("@City", City);
            adapter.UpdateCommand.Parameters.AddWithValue("@Country", Country);
            adapter.UpdateCommand.Parameters.AddWithValue("@PostNumber", PostNumber);

            con.Open();
            adapter.UpdateCommand.ExecuteNonQuery();
            con.Close();

        }
        public void deleteCustomer()
        {
            SqlCommand sql_com = new SqlCommand("uspDelUser", con);
            adapter.DeleteCommand = sql_com;
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adapter.DeleteCommand.Parameters.AddWithValue("@UserID", UserID);

            con.Open();
            adapter.DeleteCommand.ExecuteNonQuery();
            con.Close();
        }

        public DataTable selectCustomer()
        {
                SqlCommand sql_com = new SqlCommand("uspSelectUser", con);
                adapter.SelectCommand = sql_com;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@UserID", UserID);

                con.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.SelectCommand.ExecuteNonQuery();
                con.Close();

                return dt;
           
        }
    }
}
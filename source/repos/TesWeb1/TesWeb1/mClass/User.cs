using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using NoomLibrary;

namespace TesWeb1
{
    public class UserDic : IDictionary<int, UserDic.User>
    {
        private CStatement _statememet;

        public Dictionary<int, UserDic.User> userdic = new Dictionary<int, UserDic.User>();
        public UserDic()
        {
            this._statememet = new CStatement("uspGetUser", "uspAddUser", "uspUpdateUser", "uspDelUser", System.Data.CommandType.StoredProcedure);
        }

        #region imprememt
        public User this[int key] { get => ((IDictionary<int, User>)userdic)[key]; set => ((IDictionary<int, User>)userdic)[key] = value; }

        public ICollection<int> Keys => ((IDictionary<int, User>)userdic).Keys;

        public ICollection<User> Values => ((IDictionary<int, User>)userdic).Values;

        public int Count => ((IDictionary<int, User>)userdic).Count;

        public bool IsReadOnly => ((IDictionary<int, User>)userdic).IsReadOnly;

        public void Add(int key, User value)
        {
            ((IDictionary<int, User>)userdic).Add(key, value);
        }

        public void Add(KeyValuePair<int, User> item)
        {
            ((IDictionary<int, User>)userdic).Add(item);
        }

        public void Clear()
        {
            ((IDictionary<int, User>)userdic).Clear();
        }

        public bool Contains(KeyValuePair<int, User> item)
        {
            return ((IDictionary<int, User>)userdic).Contains(item);
        }

        public bool ContainsKey(int key)
        {
            return ((IDictionary<int, User>)userdic).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<int, User>[] array, int arrayIndex)
        {
            ((IDictionary<int, User>)userdic).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<int, User>> GetEnumerator()
        {
            return ((IDictionary<int, User>)userdic).GetEnumerator();
        }

        public bool Remove(int key)
        {
            return ((IDictionary<int, User>)userdic).Remove(key);
        }

        public bool Remove(KeyValuePair<int, User> item)
        {
            return ((IDictionary<int, User>)userdic).Remove(item);
        }

        public bool TryGetValue(int key, out User value)
        {
            return ((IDictionary<int, User>)userdic).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<int, User>)userdic).GetEnumerator();
        }

        #endregion

        public void selectUsers()
        {
            object result = null;
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Select);
                adlist.Add(csv);
                cstate.Open();

                result = cstate.Execute(adlist);
                DataTable dt = (DataTable)result;

                this.userdic = dt.ToDictionary<int, User>("UserID");
                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }
        public void editUsers(string firstname,string lastname,string email,string username,int userid,string tel,string gender,string brithday,string numaddress,string tambon,string amphoe,string city,string country,string postnumber)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@UserID", DbType.Int32, userid, ParameterDirection.Input);
                plist.Add("@FirstName", DbType.String, firstname, ParameterDirection.Input);
                plist.Add("@LastName", DbType.String, lastname, ParameterDirection.Input);
                plist.Add("@Email", DbType.String, email, ParameterDirection.Input);
                plist.Add("@Username", DbType.String, username, ParameterDirection.Input);
                plist.Add("@Tel", DbType.String, tel, ParameterDirection.Input);
                plist.Add("@Gender", DbType.String, gender, ParameterDirection.Input);
                plist.Add("@BrithDay", DbType.String, brithday, ParameterDirection.Input);
                plist.Add("@NumAddress", DbType.String, numaddress, ParameterDirection.Input);
                plist.Add("@Amphoe", DbType.String, amphoe, ParameterDirection.Input);
                plist.Add("@Tumbun", DbType.String, tambon, ParameterDirection.Input);
                plist.Add("@Country", DbType.String, country, ParameterDirection.Input);
                plist.Add("@City", DbType.String, city, ParameterDirection.Input);
                plist.Add("@PostNumber", DbType.String, postnumber, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Update);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }
        public void addUsers(int userid, string firstname,string lastname,string username,string tel,string email,string gen,string numaddress,string tambon,string amphoe,string city,string country,string postnumber,string birthday)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@UserID", DbType.Int32, userid, ParameterDirection.Input);
                plist.Add("@FirstName", DbType.String, firstname, ParameterDirection.Input);
                plist.Add("@LastName", DbType.String, lastname, ParameterDirection.Input);
                plist.Add("@Email", DbType.String, email, ParameterDirection.Input);
                plist.Add("@Username", DbType.String, username, ParameterDirection.Input);
                plist.Add("@Tel", DbType.String, tel, ParameterDirection.Input);
                plist.Add("@Gender", DbType.String, gen, ParameterDirection.Input);
                plist.Add("@BrithDay", DbType.String, birthday, ParameterDirection.Input);
                plist.Add("@NumAddress", DbType.String, numaddress, ParameterDirection.Input);
                plist.Add("@Amphoe", DbType.String, amphoe, ParameterDirection.Input);
                plist.Add("@Tumbun", DbType.String, tambon, ParameterDirection.Input);
                plist.Add("@Country", DbType.String, country, ParameterDirection.Input);
                plist.Add("@City", DbType.String, city, ParameterDirection.Input);
                plist.Add("@PostNumber", DbType.String, postnumber, ParameterDirection.Input);


                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Insert);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }
        public void delUsers(int userid)
        {
            CStatementList cstate = new CStatementList(Connection.CSQLConnection);
            try
            {
                CSQLParameterList plist = new CSQLParameterList();
                plist.Add("@UserID", DbType.Int32, userid, ParameterDirection.Input);

                CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                CSQLStatementValue csv = new CSQLStatementValue(this._statememet, plist, NoomLibrary.StatementType.Delete);
                adlist.Add(csv);
                cstate.Open();

                cstate.Execute(adlist);

                cstate.Commit();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                cstate.Rollback();
            }
            finally
            {
                cstate.Close();
            }
        }


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
            public string PostNumber { get; set; }
            public string BrithDay { get; set; }


            public User() { }
            public User(int userid) { }
            public User(string firstname, string lastname, string email, string username, int userid, string tel, string gender, string brithday, string numaddress, string tambon, string amphoe, string city, string country, string postnumber) { }

            public User(int userid, string firstname, string lastname, string username, string tel, string email, string gen, string numaddress, string tambon, string amphoe, string city, string country, string postnumber, string birthday) { }

            //public DataSet selectUser()
            //{
            //    SqlCommand sql_com = new SqlCommand("uspGetUser", con);
            //    adapter.SelectCommand = sql_com;
            //    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //    con.Open();
            //    DataSet dt = new DataSet();
            //    adapter.Fill(dt);
            //    con.Close();

            //    return dt;
            //}

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
                adapter.InsertCommand.Parameters.AddWithValue("@BrithDay", BrithDay);
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
                adapter.UpdateCommand.Parameters.AddWithValue("@UserID", UserID);
                adapter.UpdateCommand.Parameters.AddWithValue("@FirstName", FirstName);
                adapter.UpdateCommand.Parameters.AddWithValue("@LastName", LastName);
                adapter.UpdateCommand.Parameters.AddWithValue("@Email", Email);
                adapter.UpdateCommand.Parameters.AddWithValue("@Tel", Tel);
                adapter.UpdateCommand.Parameters.AddWithValue("@Username", Username);
                adapter.UpdateCommand.Parameters.AddWithValue("@BrithDay", BrithDay);
                adapter.UpdateCommand.Parameters.AddWithValue("@Gender", Gender);
                adapter.UpdateCommand.Parameters.AddWithValue("@NumAddress", NumAddress);
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
}
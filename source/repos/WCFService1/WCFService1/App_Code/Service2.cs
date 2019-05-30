using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
public class Service2 : IOrder,IUser
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString);
    Order order;
    User user;

    int status = 0;
    public List<Order> GetOrder(int orderid)
    {
        List<Order> orderlist = new List<Order>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspSelectOrder", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@OrderID", orderid);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();
            foreach (DataRow item in ds.Rows)
            {
                order = new Order()
                {
                    OrderID = Convert.ToInt32(item["OrderID"]),
                    ProductName = item["ProductName"].ToString(),
                    ProductPrice = Convert.ToInt32(item["ProductPrice"]),
                    FirstName = item["FirstName"].ToString(),
                    LastName = item["LastName"].ToString(),
                    OrderQty = Convert.ToInt32(item["OrderQty"]),
                    OrderPrice = Convert.ToInt32(item["OrderPrice"]),
                    OrderTime = Convert.ToDateTime(item["OrderTime"]),
                };
                orderlist.Add(order);

            }
        }
        catch (Exception)
        {
            orderlist = null;
        }
        finally
        {
            con.Close();
        }
        return orderlist;
    }
    public List<Order> GetOrderList()
    {
        List<Order> orderlist = new List<Order>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspGetOrder", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();
            foreach (DataRow item in ds.Rows)
            {
                order = new Order()
                {
                    OrderID = Convert.ToInt32(item["OrderID"]),
                    ProductName = item["ProductName"].ToString(),
                    ProductPrice = Convert.ToInt32(item["ProductPrice"]),
                    FirstName = item["FirstName"].ToString(),
                    LastName = item["LastName"].ToString(),
                    OrderQty = Convert.ToInt32(item["OrderQty"]),
                    OrderPrice = Convert.ToInt32(item["OrderPrice"]),
                    OrderTime = Convert.ToDateTime(item["OrderTime"]),
                };
                orderlist.Add(order);

            }
        }
        catch (Exception)
        {
            orderlist = null;
        }
        finally
        {
            con.Close();
        }
        return orderlist;
    }
    public List<Order> SearchOrderList(string keyword)
    {
        List<Order> orderlist = new List<Order>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspSearchOrder", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@KeyTime", keyword);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();
            foreach (DataRow item in ds.Rows)
            {
                order = new Order()
                {
                    OrderID = Convert.ToInt32(item["OrderID"]),
                    ProductName = item["ProductName"].ToString(),
                    ProductPrice = Convert.ToInt32(item["ProductPrice"]),
                    FirstName = item["FirstName"].ToString(),
                    LastName = item["LastName"].ToString(),
                    OrderQty = Convert.ToInt32(item["OrderQty"]),
                    OrderPrice = Convert.ToInt32(item["OrderPrice"]),
                    OrderTime = Convert.ToDateTime(item["OrderTime"]),
                };
                orderlist.Add(order);

            }
        }
        catch (Exception)
        {
            orderlist = null;
        }
        finally
        {
            con.Close();
        }
        return orderlist;
    }
    public int AddOrder(int pro_id,int qty,int price,int userid,DateTime ordertime)
    {
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspAddOrder", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.InsertCommand = sql_com;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.AddWithValue("@ProductID",pro_id);
            adapter.InsertCommand.Parameters.AddWithValue("@OrderQty", qty);
            adapter.InsertCommand.Parameters.AddWithValue("@OrderPrice", price);
            adapter.InsertCommand.Parameters.AddWithValue("@UserID", userid);
            adapter.InsertCommand.Parameters.AddWithValue("@OrderTime", ordertime);
            sql_com.ExecuteNonQuery();
            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }
    public int DeleteOder(int orderid)
    {
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspDelOrder", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.DeleteCommand = sql_com;
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adapter.DeleteCommand.Parameters.AddWithValue("@OrderID ", orderid);

            sql_com.ExecuteNonQuery();
            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public List<User> GetUserList()
    {
        List<User> userlist = new List<User>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspGetUser", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();
            foreach (DataRow item in ds.Rows)
            {
                user = new User()
                {
                    FirstName = item["FirstName"].ToString(),
                    LastName = item["LastName"].ToString(),
                    Email = item["Email"].ToString(),
                    Tel = item["Tel"].ToString(),
                    Gender = item["Gender"].ToString(),
                    UserName = item["Username"].ToString(),
                    BrithDay = Convert.ToDateTime(item["BrithDay"]),
                    NumAddress = item["NumAddress"].ToString(),
                    Tambon = item["Tambon"].ToString(),
                    Amphoe = item["Amphoe"].ToString(),
                    City = item["City"].ToString(),
                    Country = item["Country"].ToString(),
                    PostNumber = item["PostNumber"].ToString(),
                    UserID = Convert.ToInt32(item["UserID"])
                };
                userlist.Add(user);

            }
        }
        catch (Exception)
        {
            userlist = null;
        }
        finally
        {
            con.Close();
        }
        return userlist;
    }
    public List<User> GetUser(int userid)
    {
        List<User> userlist = new List<User>();
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspSelectUser", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.SelectCommand = sql_com;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@UserID", userid);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            sql_com.ExecuteNonQuery();
            foreach (DataRow item in ds.Rows)
            {
                user = new User()
                {
                    FirstName = item["FirstName"].ToString(),
                    LastName = item["LastName"].ToString(),
                    Email = item["Email"].ToString(),
                    Tel = item["Tel"].ToString(),
                    Gender = item["Gender"].ToString(),
                    UserName = item["Username"].ToString(),
                    BrithDay = Convert.ToDateTime(item["BrithDay"]),
                    NumAddress = item["NumAddress"].ToString(),
                    Tambon = item["Tambon"].ToString(),
                    Amphoe = item["Amphoe"].ToString(),
                    City = item["City"].ToString(),
                    Country = item["Country"].ToString(),
                    PostNumber = item["PostNumber"].ToString(),
                    UserID = Convert.ToInt32(item["UserID"])
                };
                userlist.Add(user);

            }
        }
        catch (Exception)
        {
            userlist = null;
        }
        finally
        {
            con.Close();
        }
        return userlist;
    }
    public int AddUser(int userid,string firstname,string lastname,string tel,string username,string email, DateTime brithday,string gender,string numaddress,string tumbun,string amphoe,string city ,string country,string postnumber )
    {
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspAddUser", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.InsertCommand = sql_com;
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.AddWithValue("@UserID", userid);
            adapter.InsertCommand.Parameters.AddWithValue("@FirstName", firstname);
            adapter.InsertCommand.Parameters.AddWithValue("@LastName", lastname);
            adapter.InsertCommand.Parameters.AddWithValue("@Tel", tel);
            adapter.InsertCommand.Parameters.AddWithValue("@Username", username);
            adapter.InsertCommand.Parameters.AddWithValue("@Email", email);
            adapter.InsertCommand.Parameters.AddWithValue("@BrithDay", brithday);
            adapter.InsertCommand.Parameters.AddWithValue("@Gender", gender);
            adapter.InsertCommand.Parameters.AddWithValue("@NumAddress", numaddress);
            adapter.InsertCommand.Parameters.AddWithValue("@Tumbun", tumbun);
            adapter.InsertCommand.Parameters.AddWithValue("@Amphoe", amphoe);
            adapter.InsertCommand.Parameters.AddWithValue("@City", city);
            adapter.InsertCommand.Parameters.AddWithValue("@Country", country);
            adapter.InsertCommand.Parameters.AddWithValue("@Postnumber", postnumber);
            sql_com.ExecuteNonQuery();
            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }
    public int UpdateUser(int userid, string firstname, string lastname, string tel, string username, string email, DateTime brithday, string gender, string numaddress, string tumbun, string amphoe, string city, string country, string postnumber)
    {
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspUpdateUser", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.UpdateCommand = sql_com;
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adapter.UpdateCommand.Parameters.AddWithValue("@UserID", userid);
            adapter.UpdateCommand.Parameters.AddWithValue("@FirstName", firstname);
            adapter.UpdateCommand.Parameters.AddWithValue("@LastName", lastname);
            adapter.UpdateCommand.Parameters.AddWithValue("@Tel", tel);
            adapter.UpdateCommand.Parameters.AddWithValue("@Username", username);
            adapter.UpdateCommand.Parameters.AddWithValue("@Email", email);
            adapter.UpdateCommand.Parameters.AddWithValue("@BrithDay", brithday);
            adapter.UpdateCommand.Parameters.AddWithValue("@Gender", gender);
            adapter.UpdateCommand.Parameters.AddWithValue("@NumAddress", numaddress);
            adapter.UpdateCommand.Parameters.AddWithValue("@Tumbun", tumbun);
            adapter.UpdateCommand.Parameters.AddWithValue("@Amphoe", amphoe);
            adapter.UpdateCommand.Parameters.AddWithValue("@City", city);
            adapter.UpdateCommand.Parameters.AddWithValue("@Country", country);
            adapter.UpdateCommand.Parameters.AddWithValue("@Postnumber", postnumber);
            sql_com.ExecuteNonQuery();
            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }
    public int DeleteUser(int userid)
    {
        con.Open();
        SqlCommand sql_com = new SqlCommand("uspDelUser", con);
        SqlDataAdapter adapter = new SqlDataAdapter(sql_com);
        try
        {
            adapter.DeleteCommand = sql_com;
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adapter.DeleteCommand.Parameters.AddWithValue("@UserID", userid);

            sql_com.ExecuteNonQuery();
            status = 1;
        }
        catch (Exception)
        {
            status = 0;
        }
        finally
        {
            con.Close();
        }
        return status;
    }
}
